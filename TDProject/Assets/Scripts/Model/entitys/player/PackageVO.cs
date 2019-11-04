using System;

namespace Dev.mvc
{
    [Serializable]
    public class PackageVO : VOBase
    {
        public ItemVO[] items;
        public int packSpace; 
        protected override void _onInit ()
        {
            base._onInit();
            Array.Resize<ItemVO>(ref items, packSpace);
        }
    }
}