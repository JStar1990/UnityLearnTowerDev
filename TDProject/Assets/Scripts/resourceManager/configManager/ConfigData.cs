using System;

namespace Dev.config
{
    /**配置数据，用于保存json文件序列化数据*/
    [Serializable]
    public class ConfigData<T> : ConfigDataBase where T : BaseResource
    {
        public T[] configs;

        public override BaseResource[] ConfigList()
        {
            return configs;
        }
    }
}