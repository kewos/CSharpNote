using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Common.Attributes
{
    /// <summary>
    ///     實作Aop
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MarkedRepositoryAttribue : ContextAttribute, IContributeObjectSink
    {
        /// <summary>
        ///     裝飾池
        /// </summary>
        private readonly List<Func<IMessageSink, IMessageSink>> decoratorList;

        public MarkedRepositoryAttribue()
            : base("MarkedRepositoryAttribue")
        {
            decoratorList = new List<Func<IMessageSink, IMessageSink>>
            {
                next => new RequiredDecorator(next),
                next => new TimeExecuteDecorator(next)
            };
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return decoratorList.Decorate(next);
        }
    }
}