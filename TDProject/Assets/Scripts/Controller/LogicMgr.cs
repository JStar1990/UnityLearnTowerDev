using System;
using System.Collections.Generic;
using UnityEngine;
using Dev.debug;

namespace Dev.mvc
{
    public class LogicMgr
    {
        static LogicMgr _inst = null;
        public static LogicMgr Inst
        {
            get
            {
                if (_inst == null) _inst = new LogicMgr();
                return _inst;
            }
        }

        private Dictionary<string, LogicBase> _mgr = null;

        public void Init ()
        {
            _mgr = new Dictionary<string, LogicBase>();
            _registerList();
        }

        /**logic类注册列表*/
        private void _registerList ()
        {
            _register("LogicPackage");
            _register("LogicMain");
            _register("LogicGM");
            _register("LogicSerial");
        }
        private void _register ( string key )
        {
            Type T = Type.GetType(this.GetType().Namespace + "." + key);
            if ( T != null )
            {
                LogicBase inst = (LogicBase)Activator.CreateInstance(T);
                inst.Init();
                _mgr.Add(key, inst);
            }
            else
            {
                DevDebug.Log("Register [" + key + "] is Error! Class ["+key+"] is not found!");
            }
        }

        public LogicBase mgr ( string key )
        {
            if ( _mgr.ContainsKey(key) )
            {
                return _mgr[key];
            }
            DevDebug.Log("["+key+"] is NULL! Please Register First");
            return null;
        }

        /**背包控制器*/
        public static LogicPackage logicPack
        {
            get { return LogicMgr.Inst.mgr("LogicPackage") as LogicPackage; }
        }

        public static LogicMain logicMain
        {
            get { return LogicMgr.Inst.mgr("LogicMain") as LogicMain; }
        }

        public static LogicGM logicGM
        {
            get { return LogicMgr.Inst.mgr("LogicGM") as LogicGM; }
        }

        public static LogicSerial logicSerial
        {
            get { return LogicMgr.Inst.mgr("LogicSerial") as LogicSerial; }
        }
    }
}