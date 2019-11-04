using System.Collections.Generic;

namespace Dev.mvc
{
    public class LGUIPackageView : LGUIBase
    {
        //private int _curPage = 1;
        //private int _maxPage = 1;
        public override void Open( object data = null )
        {
            base.Open(data);

            _initPackage();
        }

        public void ShowPackage ()
        {
            ItemVO[] list = EntityDataMgr.Inst.mainPlayerVo.packageVo.items;

            (uiCtrl as UIPackageView).ShowPackageList(list);
        }

        protected override void _callBack ( string type, object data = null )
        {
            switch (type)
            {
                case "initPack":
                    _initPackage();
                    break;
                case "openTips":
                    LGUIHost.Inst.itemTips.Open(data);
                    break;
                case "closeTips":
                    LGUIHost.Inst.itemTips.Close();
                    break;
                default:
                    break;
            }
        }

        private void _initPackage ()
        {
            ShowPackage();
        }

        public void UpdatePackage ()
        {
            if (this._isOpen)
                ShowPackage();
        }
    }
}