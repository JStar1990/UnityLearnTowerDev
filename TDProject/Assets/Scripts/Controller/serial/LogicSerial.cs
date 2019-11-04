namespace Dev.mvc
{
    public class LogicSerial : LogicBase
    {
        private SerialNumberVO _serialNumVo = null;

        public uint GetSerialNum ( string tp )
        {
            switch (tp)
            {
                case "item":
                    return vo.ItemNumber++;
                default:
                    break;
            }
            return 0;
        }

        private SerialNumberVO vo
        {
            get {
                if (_serialNumVo == null)
                {
                    _serialNumVo = EntityDataMgr.Inst.mainPlayerVo.serialNumberVo;
                }
                return _serialNumVo;
            }
        }
    }
}