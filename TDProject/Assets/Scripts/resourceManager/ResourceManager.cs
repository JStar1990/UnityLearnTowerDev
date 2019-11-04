using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dev
{
    public class ResourceManager
    {
        public static ResourceManager _inst = null;

        public static ResourceManager Inst
        {
            get
            {
                if (_inst == null)
                    _inst = new ResourceManager();
                return _inst;
            }
        }
    }
}