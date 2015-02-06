﻿using System;

namespace CSharpNote.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DisplayMethodAttribute : Attribute
    {
        private string reference;
        private string comment;
        private string date;
        private bool display;

        public DisplayMethodAttribute() { }
        private DisplayMethodAttribute(bool display)
        {
            this.display = display;
        }

        public DisplayMethodAttribute(string reference, bool display = false)
            : this(display)
        {
            this.reference = reference;
        }

        public DisplayMethodAttribute(string reference, string date, bool display = false)
            : this(reference, display)
        {
            this.date = date;
        }

        public DisplayMethodAttribute(string reference, string date, string comment, bool display = false)
            : this(reference, date, display)
        {
            this.comment = comment;
        }

        public string Reference { get { return reference; } }
        public string Comment { get { return comment; } }
        public string Date { get { return date; } }
        public bool Display { get { return display; } }
    }
}