using System.Collections.Generic;
using System;
using Dev.debug;

namespace Dev.mvc
{
    public class LGUIHost
    {
        static LGUIHost _inst = null;
        public static LGUIHost Inst
        {
            get
            {
                if (_inst == null) _inst = new LGUIHost();
                return _inst;
            }
        }

        private Dictionary<string, string> _registerLgui = null;
        private Dictionary<string, LGUIBase> _host = null;

        public LGUIHost ()
        {
            _onInit();
        }

        private void _onInit ()
        {
            _registerLgui = new Dictionary<string, string>();
            _host = new Dictionary<string, LGUIBase>();

            _registerList();
        }

        private void _registerList()
        {
            _register("LGUIPackageView");
            _register("LGUIGmView");
        }

        private void _register(string key)
        {
            _registerLgui.Add(key, key);
        }

        private LGUIBase _creatLgui (string key)
        {
            Type T = Type.GetType(this.GetType().Namespace + "." + key);
            if (T != null)
            {
                LGUIBase inst = (LGUIBase)Activator.CreateInstance(T);
                inst.Init();
                _host.Add(key, inst);
                return inst;
            }
            else
            {
                DevDebug.Log("Register [" + key + "] is Error! Class [" + key + "] is not found!");
            }
            return null;
        }

        private LGUIBase _lgui ( string key )
        {
            if (!_host.ContainsKey(key)) _creatLgui(key);
            return _host[key];
        }

        public LGUIPackageView package
        {
            get {
                return _lgui("LGUIPackageView") as LGUIPackageView;
            }
        }

        public LGUIGmView gm
        {
            get
            {
                return _lgui("LGUIGmView") as LGUIGmView;
            }
        }

        public LGUIItemTips itemTips
        {
            get
            {
                return _lgui("LGUIItemTips") as LGUIItemTips;
            }
        }

        public LGUIBannerView banner
        {
            get
            {
                return _lgui("LGUIBannerView") as LGUIBannerView;
            }
        }

    }
}