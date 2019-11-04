using UnityEngine;

namespace Dev.debug
{
    public class DevDebug
    {
        public static void Log (object v)
        {
            if (GameDefine.debug)
                Debug.Log( v );
        }
    }
}