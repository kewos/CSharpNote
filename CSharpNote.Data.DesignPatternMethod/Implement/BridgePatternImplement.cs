using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.BridgePattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class BridgePatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     合成代替繼承 減少藕合
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var elements = new List<IBridgeShape>
            {
                new CircleBridgeShape(new RedBridgeColor()),
                new CircleBridgeShape(new YellowBridgeColor()),
                new TriangleBridgeShape(new RedBridgeColor()),
                new TriangleBridgeShape(new YellowBridgeColor())
            };
            elements.ForEach(element => element.Display());
        }
    }
}