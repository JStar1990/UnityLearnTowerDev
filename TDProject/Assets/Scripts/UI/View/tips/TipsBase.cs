using UnityEngine.EventSystems;
using UnityEngine;
using Dev.config;
using Dev.Event;
using UnityEngine.UI;

namespace Dev.mvc
{
    public class TipsBase : UIBase
    {
        public GameObject mIcon;
        public GameObject mName;
        public GameObject mType;
        public GameObject mCount;
        public GameObject mDesc;

        protected BaseResource _config;
        protected VOBase _vo;

        protected Image _imgIcon
        {
            get { return mIcon?.GetComponent<Image>(); }
        }
        protected Text _txtName
        {
            get { return mName?.GetComponent<Text>(); }
        }
        protected Text _txtType
        {
            get { return mType?.GetComponent<Text>(); }
        }
        protected Text _txtCount
        {
            get { return mCount?.GetComponent<Text>(); }
        }
        protected Text _txtDesc
        {
            get { return mDesc?.GetComponent<Text>(); }
        }

        protected override void _onStart()
        {
            base._onStart();

            callBack("openFinish");
        }

        public void showTips ( BaseResource config,  VOBase vo )
        {
            _config = config;
            _vo = vo;

            if (config == null && vo != null)
            {
                _config = (BaseResource)vo.GetType().GetProperty("config").GetValue(vo) ;
            }

            if (_config == null) return;

            _showTips();
        }

        protected override void _addGameListen()
        {
            base._addGameListen();
            GameEvent.AddGameEvent(transform.Find("bg").gameObject, EventTriggerType.PointerClick, OnClickBg);
        }

        protected virtual void _showTips()
        {
            _showMain();
        }

        protected virtual void _showMain ()
        {

        }

        public void OnClickBg(BaseEventData data)
        {
            callBack("close");
        }
    }
}
