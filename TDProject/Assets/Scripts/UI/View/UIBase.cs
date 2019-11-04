using UnityEngine;

namespace Dev.mvc
{
    public class UIBase : MonoBehaviour
    {
        public delegate void CallBack(string type, object data = null);
        protected CallBack _callBack;

        //protected object _openData;
        public void SetCallBack(CallBack cb)
        {
            _callBack = cb;
        }

        protected void callBack (string type, object data = null)
        {
            if (_callBack != null) _callBack(type, data);
        }

        /** 子类只需要重写_onAwake方法，而不再实现Awake方法*/
        void Awake()
        {
            _onAwake();
        }
        /** 子类只需要重写_onEnable方法，而不再实现OnEnable方法*/
        void OnEnable()
        {
            _onEnable();
        }

        // Start is called before the first frame update
        /** 子类只需要重写_onStart方法，而不再实现Start方法*/
        void Start()
        {
            _onStart();
            _addGameListen();
        }

        // Update is called once per frame
        /** 子类只需要重写_onUpdate方法，而不再实现Update方法*/
        void Update()
        {
            _onUpdate();
        }
        /** 子类只需要重写_onLateUpdate方法，而不再实现LateUpdate方法*/
        void LateUpdate()
        {
            _onLateUpdate();
        }
        /** 子类只需要重写_onFixedUpdate方法，而不再实现FixedUpdate方法*/
        void FixedUpdate()
        {
            _onFixedUpdate();
        }
        /** 子类只需要重写_onDisable方法，而不再实现OnDisable方法*/
        void OnDisable()
        {
            _onDisable();
            _rmvGameListen();
        }
        /** 子类只需要重写_onDestroy方法，而不再实现OnDestroy方法*/
        void OnDestroy()
        {
            _onDestroy();
            _rmvGameListen();
        }

        protected virtual void _onAwake () { }
        protected virtual void _onEnable () { }
        protected virtual void _onStart () { }
        protected virtual void _onUpdate () { }
        protected virtual void _onLateUpdate () { }
        protected virtual void _onFixedUpdate () { }
        protected virtual void _onDisable () { }
        protected virtual void _onDestroy () { }

        /** 添加UI内监听事件，在ui start的时候会调用一次*/
        protected virtual void _addGameListen() { }
        /** 移除UI内监听事件，在ui onDisable的时候会调用一次*/
        protected virtual void _rmvGameListen() { }
        /**
        public object openData
        {
            get { return _openData; }
            set { _openData = value; }
        }*/
    }
}