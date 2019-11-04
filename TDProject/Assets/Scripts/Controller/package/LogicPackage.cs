using Dev.config;
using Dev.debug;
using Dev.tools;

namespace Dev.mvc
{
    public class LogicPackage : LogicBase
    {
        private PackageVO _packVo;

        public void AddItem ( string itemId, int count )
        {
            // 创建物品
            _tryCreateItemVo( itemId, count );
            // 通知背包信息更新
            LGUIHost.Inst.package.UpdatePackage();
        }

        private void _tryCreateItemVo (string itemId, int count)
        {
            int len = packVo.items.Length;
            ITEMRESOURCE config = ConfigManager.Inst.GetItemResourceByID(itemId);
            if (config == null)
            {
                DevDebug.Log("道具[" + itemId + "]配置不存！");
                return;// 道具配置不存在
            }

            for (int i = 0; i < len; i++)
            {
                if (packVo.items[i] == null) continue;
                if (packVo.items[i].configId != itemId) continue;
                if (packVo.items[i].count >= config.limit) continue;
                if ((packVo.items[i].count + count) > config.limit )
                {
                    count = count - config.limit + packVo.items[i].count;
                    packVo.items[i].count = config.limit;
                }
                else
                {
                    packVo.items[i].count += count;
                    count = 0;
                }
                break;
            }

            while ( count > 0 )
            {
                // 创建物品
                ItemVO itemVo = _createItemVO(itemId);
                if ( count > config.limit )
                {
                    count -= config.limit;
                    itemVo.count = config.limit;
                }
                else
                {
                    itemVo.count = count;
                    count = 0;
                }
                
                // 将物品放入到背包中
                packVo.items.SetValue(itemVo, itemVo.index);
            }
        }

        private ItemVO _createItemVO ( string itemId )
        {
            ItemVO vo = new ItemVO();
            vo.configId = itemId;
            vo.id = LogicMgr.logicSerial.GetSerialNum("item");
            vo.index = _emptyIndex;
            
            return vo;
        }

        private int _emptyIndex
        {
            get
            {
                int len = packVo.items.Length;
                for (int i = 0; i < len; i++)
                {
                    if (packVo.items[i] == null) return i;
                }
                return 0;
            }
        }

        /**获取道具在背包中的数量*/
        public int GetItemCount ( string itemId )
        {
            int count = 0;
            for ( int i = 0; i < packVo.items.Length; ++i )
            {
                if (packVo.items[i] == null) continue;
                if (packVo.items[i].configId != itemId) continue;
                count += packVo.items[i].count;
            }
            return count;
        }

        public string GetItemDesc ( ITEMRESOURCE config )
        {
            string desc = "";
            foreach ( var item in config.purpose.GetType().GetFields() )
            {
                object value = config.purpose.GetType().GetField(item.Name).GetValue(config.purpose);
                desc += utils.GetString(item.Name, value.ToString());
            }
            return desc;
        }

        /** 使用指定类型的道具 */
        public void UseItem ()
        {

        }

        /** 使用某一个道具 */
        public void UseItemVo ()
        {

        }

        public PackageVO packVo
        {
            get
            {
                if (_packVo == null)
                    _packVo = EntityDataMgr.Inst.mainPlayerVo.packageVo;
                return _packVo;
            }
        }
    }
}