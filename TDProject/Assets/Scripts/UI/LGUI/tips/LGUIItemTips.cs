namespace Dev.mvc
{
    public class LGUIItemTips : LGUIBase
    {
        private UIItemTips _uiTips
        {
            get { return (UIItemTips)uiCtrl; }
        }

        protected override void _callBack(string type, object data = null)
        {
            switch (type)
            {
                case "openFinish":
                    _onOpenShow();
                    break;
                case "close":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        
        private void _onOpenShow ()
        {
            
            //object vo;
            //bool succ = _openData.TryGetValue("vo", out vo);
            _uiTips.showTips(null, (VOBase)(_openData.GetType().GetProperty("vo").GetValue(_openData)));
        }
    }
}