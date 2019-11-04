using Dev.GM;

namespace Dev.mvc
{
    public class LGUIGmView : LGUIBase
    {
        protected override void _callBack(string type, object data = null)
        {
            switch (type)
            {
                case "onSend":
                    LGGM.Inst.SendGMCode(data.ToString());
                    break;
                case "onSave":
                    break;
                default:
                    break;
            }
        }
    }
}