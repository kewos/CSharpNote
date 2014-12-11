using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Common;
using ConsoleDisplay.Data;

namespace ConsoleDisplay.Client
{
    /// <summary>
    /// 方法管理
    /// </summary>
    public class MethodManager
    {
        private static Lazy<MethodManager> instance = new Lazy<MethodManager>(() => new MethodManager());
        public static MethodManager Instance { get { return instance.Value; } }

        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private MethodManager() { }

        /// <summary>
        /// 呈現方法清單
        /// </summary>
        /// <param name="project">執行的方案</param>
        public void Display(AbstractDisplayMethods project)
        {
            var items = project.MethodInfos.Select(method => method.Name);
            ConsoleDisplayer.Instance.Excute(items, index => Excute(index, project));
        }

        /// <summary>
        /// 執行所選擇的方法
        /// </summary>
        /// <param name="index">選擇的方法</param>
        /// <param name="project">執行的方案</param>
        private void Excute(int index, AbstractDisplayMethods project)
        {
            if (index >= project.MethodInfos.Count || index < 0)
            {
                throw new ArgumentException("invalid argument");
            }

            project.MethodInfos[index].Invoke(project, null);
        }
    }
}
