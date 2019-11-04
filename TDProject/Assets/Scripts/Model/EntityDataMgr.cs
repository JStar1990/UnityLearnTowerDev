
namespace Dev.mvc
{
    public class EntityDataMgr
    {
        static EntityDataMgr _inst = null;
        public static EntityDataMgr Inst
        {
            get
            {
                if (_inst == null) _inst = new EntityDataMgr();
                return _inst;
            }
        }

        private MainPlayerVO _mainPlayerVo = null;

        public EntityDataMgr ()
        {
            _onInit();
        }

        private void _onInit ()
        {
            _mainPlayerVo = new MainPlayerVO();
        }

        public MainPlayerVO mainPlayerVo
        {
            get { return _mainPlayerVo; }
        }

        public void SetMainPlayer ( string obj )
        {
            mainPlayerVo.Init(obj);
        }
    }
}