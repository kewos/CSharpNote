using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.PrototypePattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class PrototypePatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     實作IClone透過複製來產生實體
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            var colormanager = new ColorManager();

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            colormanager["red"].Display();
            colormanager["green"].Display();
            colormanager["blue"].Display();
        }
    }
}