﻿using System;

namespace CSharpNote.Data.DesignPattern.Implement.ObjectPoolPattern
{
    public class PooledObject
    {
        private readonly DateTime createdAt;

        public PooledObject()
        {
            createdAt = DateTime.Now;
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public string TempData { get; set; }
    }
}