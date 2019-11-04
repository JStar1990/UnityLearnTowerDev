using UnityEngine;
using Dev.config;
using Dev.mvc;

namespace Dev
{
    public class Main : MonoBehaviour
    {
        const float devHeight = 10.24f;
        const float devWidth = 7.68f;
        // Start is called before the first frame update
        void Start()
        {
            //_screenAdaptation();
            // 初始化配置管理器
            ConfigManager.Inst.Init();
            // 初始化所有controller
            LogicMgr.Inst.Init();

            LogicMgr.logicMain.GameInit();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void _screenAdaptation ()
        {
            float screenHeight = Screen.height;
            Dev.debug.DevDebug.Log("screenHeight:" + screenHeight);
            float screenWidth = Screen.width;

            float orthographicSize = this.GetComponent<Camera>().orthographicSize;

            float aspectRatio = Screen.width * 1.0f / Screen.height;
            float cameraWidth = orthographicSize * 2 * aspectRatio;
            float cameraHeight = orthographicSize * 2 * (1 / aspectRatio);
            Dev.debug.DevDebug.Log("cameraWidth:" + cameraWidth);
            Dev.debug.DevDebug.Log("cameraHeight:" + cameraHeight);

            if ( cameraWidth < devWidth )
            {
                orthographicSize = devWidth / (2 * aspectRatio);
                Dev.debug.DevDebug.Log("new orthographicSize = " + orthographicSize);
                this.GetComponent<Camera>().orthographicSize = orthographicSize;
            }
        }
    }
}