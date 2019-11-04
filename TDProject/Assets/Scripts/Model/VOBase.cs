using System;
using UnityEngine;

namespace Dev.mvc
{
    [Serializable]
    public class VOBase
    {
        public void Init(string obj)
        {
            JsonUtility.FromJsonOverwrite(obj, this);
            init();
        }

        public void init ()
        {
            this._onInit();
            foreach (var item in this.GetType().GetFields())
            {
                VOBase vo = this.GetType().GetField(item.Name).GetValue(this) as VOBase;
                if (vo != null)
                {
                    vo.init();
                }
            }
        }

        protected virtual void _onInit ()
        {

        }
    }
}