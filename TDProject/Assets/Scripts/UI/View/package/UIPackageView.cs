using UnityEngine;

namespace Dev.mvc
{
    public class UIPackageView : UIBase
    {
        private const int PACK_ROW = 7;
        private const int PACK_COL = 10;

        private GameObject[] _packageList;

        protected override void _onStart()
        {
            base._onStart();
            _initPackageList();

            _callBack("initPack");
        }

        private void _initPackageList ()
        {
            GameObject cell = null;
            Transform package = transform.Find("main").Find("packCells");
            int len = PACK_ROW * PACK_COL;
            _packageList = new GameObject[PACK_ROW * PACK_COL];
            for (int i = 0; i < len; ++i)
            {
                cell = (GameObject)Resources.Load("Prefabs/UI/packageCell");
                cell = Instantiate(cell);
                cell.name = "cellBackgournd_" + i;
                cell.transform.SetParent(package);
                cell.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(75 * (i % PACK_COL), -75 * (i / PACK_COL), 0);
                UITilePackageCell tile = cell.GetComponent<UITilePackageCell>();
                tile.SetCallBack(callBack);
                _packageList.SetValue(cell, i);
            }
        }

        public void ShowPackageList ( ItemVO[] items )
        {
            if (_packageList == null) return;

            for ( int i = 0; i < _packageList.Length; ++i )
            {
                GameObject cell = _packageList[i];
                UITilePackageCell tile = cell.GetComponent<UITilePackageCell>();
                if ( i < items.Length )
                {
                    tile.Show(items[i]);
                }
                else
                {
                    tile.Clear();
                }
            }
        }
    }
}