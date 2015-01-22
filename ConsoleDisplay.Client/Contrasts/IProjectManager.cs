﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDisplay.Data.Contracts;

namespace ConsoleDisplay.Client.Contrasts
{
    public interface IProjectManager
    {
        /// <summary>
        /// 呈現專案清單
        /// </summary>
        void Display();
    }
}