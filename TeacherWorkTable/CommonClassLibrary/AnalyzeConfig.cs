using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace TeacherWorkTable
{
    public class Camera
    {
        public string name { get; set; }
        public string ip { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string rtsp_url { get; set; }

        public override string ToString()
        {
            return name + "(" + ip + ")";
        }
    }

    public class Test
    {
        public string rtsp_url { get; set; }
        public string rtmp_url { get; set; }
    }

    public class RootObject
    {
        public List<Camera> camera { get; set; }
        public string server { get; set; }
        public Test test { get; set; }
    }

    public class AnalyzeConfig
    {
        public string strConfigFile = "./config.json";
        public RootObject configRoot;
        private AnalyzeConfig()
        {
            string strJson = "";
            try
            {
                if (File.Exists(strConfigFile))
                {
                    strJson = File.ReadAllText(strConfigFile);
                }
                else
                {
                    //MessageBox.Show("配置文件不存在");
                }
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            configRoot = JsonConvert.DeserializeObject<RootObject>(strJson);
        }
        // 定义一个静态变量来保存类的实例
        private static AnalyzeConfig uniqueInstance;

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static AnalyzeConfig GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueInstance == null)
            {
                uniqueInstance = new AnalyzeConfig();
            }
            return uniqueInstance;
        }
    }
}
