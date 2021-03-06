﻿using System;

namespace CSharpNote.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class AopTargetAttribute : Attribute
    {
        private readonly string comment;
        private readonly string date;
        private readonly bool display;
        private readonly string reference;

        public AopTargetAttribute()
        {
        }

        private AopTargetAttribute(bool display)
        {
            this.display = display;
        }

        public AopTargetAttribute(string reference, bool display = false)
            : this(display)
        {
            this.reference = reference;
        }

        public AopTargetAttribute(string reference, string date, bool display = false)
            : this(reference, display)
        {
            this.date = date;
        }

        public AopTargetAttribute(string reference, string date, string comment, bool display = false)
            : this(reference, date, display)
        {
            this.comment = comment;
        }

        public string Reference
        {
            get { return reference; }
        }

        public string Comment
        {
            get { return comment; }
        }

        public string Date
        {
            get { return date; }
        }

        public bool Display
        {
            get { return display; }
        }
    }
}