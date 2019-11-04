using Dev.config;

namespace Dev.tools
{
    public class utils
    {
        static ReLanguageResource _reLanguage;
        static ReLanguageResource ReLanguage
        {
            get
            {
                if (utils._reLanguage == null) utils._reLanguage = ((ReLanguageResource)ConfigManager.Inst.reBase("LANGUAGERESOURCE"));
                return utils._reLanguage;
            }
        }

        public static string GetString ( string key )
        {
            return ReLanguage.GetString(key);
        }

        public static string GetString ( string key, params string[] l )
        {
            string str = ReLanguage.GetString(key);
            str = str.Replace("{%s}", l[0]);
            return str;
        }
    }
}