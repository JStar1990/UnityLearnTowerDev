using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Dev.debug;

namespace Dev.config
{
    public class ConfigManager
    {
        public static ConfigManager _inst;
        public static ConfigManager Inst
        {
            get
            {
                if (_inst == null)
                    _inst = new ConfigManager();
                return _inst;
            }
        }

        /*主配置文件*/
        private string _mainName = "MainResource";
        private Dictionary<string, ConfigDataBase> _allConfig = null;
        private Dictionary<string, ReBase> _reConfigs = null;
        /** 初始化配置文件*/
        public void Init()
        {
            //先加载主文件配置
            TextAsset text = Resources.Load<TextAsset>(_mainName);
            ConfigData<MAINRESOURCE> mainConfig = JsonUtility.FromJson<ConfigData<MAINRESOURCE>>(text.text);

            int len = mainConfig.configs.Length;
            _allConfig = new Dictionary<string, ConfigDataBase>(len + 1);
            _allConfig.Add("MAINRESOURCE", mainConfig);

            _reConfigs = new Dictionary<string, ReBase>();
            for (int i = 0; i < len; ++i)
            {
                _loadConfigs(mainConfig.configs[i]);
            }
        }

        /*加载main里面的所有配置*/
        private void _loadConfigs(MAINRESOURCE res)
        {
            Type T = Type.GetType(this.GetType().Namespace + "." + res.name.ToUpper());
            MethodInfo mi = this.GetType().GetMethod("AnalysisConfig").MakeGenericMethod(new Type[] { T });
            mi.Invoke(this, new object[1] { res });

            if ( res.register != null && res.register != "" ) _register(res.name, this.GetType().Namespace + "." + res.register);
        }

        public void AnalysisConfig<T>(MAINRESOURCE res) where T:BaseResource
        {
            try
            {
                TextAsset text = Resources.Load<TextAsset>(res.url);
                ConfigData<T> config = JsonUtility.FromJson<ConfigData<T>>(text.text);
                _allConfig.Add(res.name.ToUpper(), config);
            }
            catch (Exception e)
            {
                DevDebug.Log(e);
            }
        }

        private void _register ( string key, string name )
        {
            Type myClass = Type.GetType(name);
            if (myClass == null)
            {
                DevDebug.Log("[" + name + "] is not found! please create class first!");
                return;
            }
            key = key.ToUpper();
            try
            {
                ReBase reBase = (ReBase)Activator.CreateInstance(myClass);

                ConfigDataBase config = _allConfig[key];
                int len = config.ConfigList().Length;
                for (int i = 0; i < len; ++i)
                {
                    reBase.ReLoadFunc(config.ConfigList()[i], i, len);
                }

                _reConfigs.Add(key, reBase);
            }
            catch (Exception e)
            {
                DevDebug.Log(e);
            }
        }

        public ITEMRESOURCE GetItemResourceByID ( string id )
        {
            ConfigData<ITEMRESOURCE> data = (ConfigData<ITEMRESOURCE>)Config("ITEMRESOURCE");
            foreach (var item in data.configs)
            {
                if (item.id == id) return item;
            }
            return null;
        }

        public WINDOWRESOURCE GetWindowResourceByID (string id)
        {
            ConfigData<WINDOWRESOURCE> data = (ConfigData<WINDOWRESOURCE>)Config("WINDOWRESOURCE");
            foreach (var item in data.configs)
            {
                if (item.id == id) return item;
            }
            return null;
        }

        public ReBase reBase ( string key )
        {
            ReBase re;
            bool succ = _reConfigs.TryGetValue(key, out re);
            if (succ) return re;
            else return null;
        }

        public ConfigDataBase Config ( string type )
        {
            return _allConfig[type];
        }
    }
}