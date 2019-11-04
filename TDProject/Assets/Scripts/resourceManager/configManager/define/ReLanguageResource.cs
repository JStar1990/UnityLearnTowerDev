using System.Collections.Generic;

namespace Dev.config
{
    class ReLanguageResource : ReBase
    {
        private Dictionary<string, string> _library;

        public ReLanguageResource ()
        {
            _library = new Dictionary<string, string>();
        }

        public override void ReLoadFunc(BaseResource data, int index, int total)
        {
            LANGUAGERESOURCE lan = (LANGUAGERESOURCE)data;
            _library.Add(lan.key, lan.value);
        }

        public string GetString (string key)
        {
            string str;
            bool succ = _library.TryGetValue(key, out str);
            if (succ) return str;
            else return key;
        }
    }
}
