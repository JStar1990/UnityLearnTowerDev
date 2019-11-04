using System;

namespace Dev.mvc
{
    [Serializable]
    public class MainPlayerVO : PlayerVO
    {
        public PackageVO packageVo;
        public SerialNumberVO serialNumberVo;
    }
}