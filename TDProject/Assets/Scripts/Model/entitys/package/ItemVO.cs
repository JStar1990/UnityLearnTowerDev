using System;
using Dev.config;

namespace Dev.mvc
{
    [Serializable]
    public class ItemVO : VOBase
    {
        public uint id;
        public string configId;
        public int count;
        public int index;

        private ITEMRESOURCE _config;
        public ITEMRESOURCE config
        {
            get
            {
                if ( _config == null )
                {
                    _config = ConfigManager.Inst.GetItemResourceByID(configId);
                }
                return _config;
            }
        }
    }
}