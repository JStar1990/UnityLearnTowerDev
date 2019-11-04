using System;
using System.Reflection;
using System.Collections.Generic;
using Dev.mvc;

namespace Dev.GM
{
    public class LGGM
    {
        static LGGM _inst = null;
        public static LGGM Inst
        {
            get{
                if (_inst == null) _inst = new LGGM();
                return _inst;
            }
        }

        public LGGM ()
        {
            _codeData = new Dictionary<string, string>(2);
            _codeData.Add("mehtod", "");
            _codeData.Add("params", "");
        }

        private Dictionary<string, string> _codeData = null;
        public void SendGMCode ( string code )
        {
            int index = code.IndexOf(" ");
            string method = "";
            if (index == -1)
                method = code;
            else
                method = code.Substring(0, index);

            method = method.ToLower();
            MethodInfo mt = this.GetType().GetMethod(method)?.GetBaseDefinition();
            if (mt != null)
            {
                _codeData["method"] = method;
                if (index == -1)
                    _codeData["params"] = "";
                else
                    _codeData["params"] = code.Substring(index + 1);
                mt.Invoke(this, new object[1] { _codeData["params"] });
            }
        }

        public void additem ( string code )
        {
            int index = code.IndexOf(" ");
            if (index == -1) return;// 格式错误
            string itemId = code.Substring(0, index);
            int count;
            bool succ = int.TryParse(code.Substring(index + 1), out count);
            if ( !succ )
            {
                count = 1;
            }

            LogicMgr.logicGM.AddItem(itemId, count);
        }
    }
}

