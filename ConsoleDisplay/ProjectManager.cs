using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplayCommon;
using DisplayPattern;
using DisplayPractice;
using DisPlayProjectEuler;

namespace ConsoleDisplay
{
    /// <summary>
    /// 專案管理
    /// </summary>
    public class ProjectManager
    {
        public List<Type> projects = new List<Type>();

        private static Lazy<ProjectManager> instance = new Lazy<ProjectManager>(() => new ProjectManager());
        public static ProjectManager Instance { get { return instance.Value; } }

        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private ProjectManager()
        {
            projects.Add(typeof(DisplayDesignPattern));
            projects.Add(typeof(DisplayCSharpPractice));
            projects.Add(typeof(DisplayProjectEuler));
        }

        /// <summary>
        /// 呈現專案清單
        /// </summary>
        public void Display()
        {
            var items = projects.Select(project => project.Name);
            ConsoleDisplayer.Instance.Excute(items, index => Excute(index));
        }

        /// <summary>
        /// 執行所選擇的專案
        /// </summary>
        /// <param name="index">選擇的專案</param>
        public void Excute(int index)
        {
            if (index >= projects.Count || index < 0)
            {
                throw new ArgumentException("invalid argument");
            }

            var project = Activator.CreateInstance(projects[index]) as AbstractDisplayMethods;
            MethodManager.Instance.Display(project);
        }
    }
}
