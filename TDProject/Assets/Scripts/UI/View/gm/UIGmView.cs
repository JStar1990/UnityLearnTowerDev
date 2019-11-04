using UnityEngine;
using UnityEngine.UI;

namespace Dev.mvc
{
    public class UIGmView : UIBase
    {
        public GameObject inputCode;
        public GameObject btnSend;

        public void OnClickSend ()
        {
            _callBack("onSend", inputCode.GetComponent<InputField>().text );
        }

        public void OnClickSave ()
        {
            _callBack("onSave");
        }
    }
}