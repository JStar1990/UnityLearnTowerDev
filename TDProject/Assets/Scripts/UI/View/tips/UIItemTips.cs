using Dev.config;
using Dev.tools;
using UnityEngine;

namespace Dev.mvc
{
    public class UIItemTips : TipsBase
    {
        protected override void _showMain()
        {
            base._showMain();
            ITEMRESOURCE res = (ITEMRESOURCE)_config;
            _imgIcon.sprite = Resources.Load<Sprite>(res.icon);
            _txtName.text = utils.GetString(res.sname);
            _txtType.text = utils.GetString("itemType_" + res.type);
            _txtCount.text = LogicMgr.logicPack.GetItemCount(res.id).ToString();
            _txtDesc.text = LogicMgr.logicPack.GetItemDesc(res);
        }
    }
}