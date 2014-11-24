using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Xml.Linq;
using DisplayPattern.DesignPattern;
using DisplayPattern;
using ConsoleDisplayCommon;
using DisplayPractice;
using DisPlayProjectEuler;

namespace ConsoleDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectManager.Instance.Display();
        }
    }
}

