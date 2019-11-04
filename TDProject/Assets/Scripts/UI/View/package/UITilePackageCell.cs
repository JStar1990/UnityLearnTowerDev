using UnityEngine;
using UnityEngine.UI;
using Dev.Event;
using UnityEngine.EventSystems;

namespace Dev.mvc
{
    public class UITilePackageCell : UITileBase
    {
        public GameObject itemIcon;
        public GameObject txtCount;

        private ItemVO _itemVo;
        protected override void _onStart()
        {
            base._onStart();

            if (_itemVo == null) itemIcon.SetActive(false);
        }

        protected override void _addGameListen()
        {
            base._addGameListen();

            GameEvent.AddGameEvent(gameObject, EventTriggerType.PointerClick, OnClick);
        }

        public void Show(VOBase vo)
        {
            _itemVo = (ItemVO)vo;
            if ( vo == null )
            {
                Clear();
                return;
            }

            _imgIcon.sprite = Resources.Load<Sprite>(_itemVo.config.icon);
            itemIcon.SetActive(true);

            _txtCount.text = _itemVo.config.limit > 1 ? _itemVo.count.ToString():"";
        }

        public void Clear()
        {
            itemIcon.SetActive(false);
            _txtCount.text = "";
            _itemVo = null;
        }

        public void OnClick (BaseEventData data)
        {
            if (_itemVo != null)
            {
                object openData = new
                {
                    vo = _itemVo
                };
                callBack("openTips", openData);
            }
            else
            {
                callBack("closeTips");
            }
        }

        private Image _imgIcon
        {
            get { return itemIcon?.GetComponent<Image>(); }
        }
        private Text _txtCount
        {
            get { return txtCount?.GetComponent<Text>(); }
        }
    }
}