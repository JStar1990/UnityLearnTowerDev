using System.Collections.Generic;

namespace Dev.config
{
    class ReGeneralResource : ReBase
    {
        private Dictionary<string, object> _library;

        public ReGeneralResource()
        {
            _library = new Dictionary<string, object>();
        }

        public override void ReLoadFunc(BaseResource data, int index, int total)
        {
            GENERALRESOURCE item = (GENERALRESOURCE)data;
            if (item.type == "array")
            {
                _library.Add(item.key, item.value.Split(','));
            }
            else if ( item.type == "object" )
            {

                string[] strArr = item.value.Split(',');
                for ( int i = 0; i < strArr.Length; ++i )
                {
                    string[] arr = strArr[i].Split(':');

                }
            }
            else
            {
                _library.Add(item.key, item.value);
            }
        }
    }
}
