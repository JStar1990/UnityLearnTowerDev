using UnityEngine;
using Dev.config;
using System.Collections.Generic;

namespace Dev.mvc
{
    public class LGUIBase
    {
        protected GameObject _ui;
        protected UIBase _uiCtrl;
        protected bool _isOpen = false;
        protected WINDOWRESOURCE _uiConfig = null;
        private readonly string[] _layerList = { "UILayerB", "UILayerM", "UILayerT" };
        protected object _openData = null;

        public virtual void Init()
        {
            _uiConfig = ConfigManager.Inst.GetWindowResourceByID(this.name);
        }

        protected UIBase uiCtrl
        {
            get
            {
                if (_uiCtrl == null) _uiCtrl = _ui?.GetComponent<UIBase>();
                return _uiCtrl as UIBase;
            }
        }

        protected string name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public virtual void StatusSwitch ()
        {
            if ( IsOpen )
            {
                Close();
            }
            else
            {
                Open();
            }
        }

        /**界面开启统一接口*/
        public virtual void Open (object data = null )
        {
            _openData = data;
            _onOpenImpl();
        }
        /**界面关闭统一接口*/
        public virtual void Close ()
        {
            _onCloseImpl();
        }

        private void _onOpenImpl ()
        {
            if (_isOpen) return;
            if (_uiConfig == null) return;
            // 创建实例
            _ui = (GameObject)Resources.Load(_uiConfig.url);
            // 将实例添加到舞台
            string layer = "";
            if (_uiConfig.layer < 0) layer = _layerList[0];
            if (_uiConfig.layer >= _layerList.Length) layer = _layerList[_layerList.Length - 1];
            else layer = _layerList[_uiConfig.layer];
            _ui = GameObject.Instantiate(_ui, GameObject.Find(layer).transform, false);
            _ui.name = name;
            // 设置回调函数
            uiCtrl.SetCallBack(_callBack);
            // 传递开启参数
            //uiCtrl.openData = _openData;

            _isOpen = true;
        }

        private void _onCloseImpl ()
        {
            if ( _ui != null )
            {
                _isOpen = false;
                GameObject.DestroyImmediate(_ui);
                _ui = null;
            }
            _openData = null;
        }

        public bool IsOpen
        {
            get { return _isOpen; }
        }

        protected virtual void _callBack(string type, object data = null){}
    }
}