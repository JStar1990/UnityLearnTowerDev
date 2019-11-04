namespace Dev.mvc
{
    public class LogicMain : LogicBase
    {
        public void GameInit ()
        {
            //EntityDataMgr.Inst.SetMainPlayer("{\"packageVo\":{\"items\":[{\"id\": \"1\",\"configId\":\"1\", \"count\":1,\"index\":1},{\"id\":\"2\",\"configId\":\"3\", \"count\":3,\"index\":2}],\"packSpace\":104},\"serialNumberVo\":{\"ItemNumber\":3}}");

            //LGUIHost.Inst.package.StatusSwitch();
            //LGUIHost.Inst.gm.StatusSwitch();

            LGUIHost.Inst.banner.StatusSwitch();
        }
    }
}