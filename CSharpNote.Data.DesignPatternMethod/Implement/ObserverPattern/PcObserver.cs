﻿using System;

namespace CSharpNote.Data.DesignPattern.Implement.ObserverPattern
{
    public class PcObserver : ObserverBase<Rss>, IPcObserver
    {
        public override void OnNext(Rss value)
        {
            Console.WriteLine("{0}:Get Message {1}", GetType().Name, value.Message);
        }
    }
}