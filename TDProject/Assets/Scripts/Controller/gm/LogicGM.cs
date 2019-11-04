using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dev.mvc
{
    public class LogicGM : LogicBase
    {
        public void AddItem ( string itemId, int count )
        {
            LogicMgr.logicPack.AddItem(itemId, count);
        }
    }
}