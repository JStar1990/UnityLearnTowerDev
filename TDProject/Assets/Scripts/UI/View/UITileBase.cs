using UnityEngine;

namespace Dev.mvc
{
    public class UITileBase : MonoBehaviour
    {
        public delegate void CallBack(string type, object data = null);
        protected CallBack _callBack;

        //protected object _openData;
        public void SetCallBack(CallBack cb)
        {
            _callBack = cb;
        }

        protected void callBack(string type, object data = null)
        {
            if (_callBack != null) _callBack(type, data);
        }

        void Awake()
        {
            _onAwake();
        }

        void OnEnable()
        {
            _onEnable();
        }

        // Start is called before the first frame update
        void Start()
        {
            _onStart();
            _addGameListen();
        }

        // Update is called once per frame
        void Update()
        {
            _onUpdate();
        }

        void LateUpdate()
        {
            _onLateUpdate();
        }

        void FixedUpdate()
        {
            _onFixedUpdate();
        }

        void OnDisable()
        {
            _onDisable();
            _rmvGameListen();
        }

        void OnDestroy()
        {
            _onDestroy();
        }

        protected virtual void _onAwake() { }
        protected virtual void _onEnable() { }
        protected virtual void _onStart() { }
        protected virtual void _onUpdate() { }
        protected virtual void _onLateUpdate() { }
        protected virtual void _onFixedUpdate() { }
        protected virtual void _onDisable() { }
        protected virtual void _onDestroy() { }

        /** 添加UI内监听事件*/
        protected virtual void _addGameListen() { }
        /** 移除UI内监听事件*/
        protected virtual void _rmvGameListen() { }
    }
}