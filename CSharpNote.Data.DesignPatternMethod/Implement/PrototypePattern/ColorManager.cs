using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern
{
    public class ColorManager : IColorManager
    {
        private readonly Dictionary<string, IColor> colors;

        public ColorManager()
        {
            colors = new Dictionary<string, IColor>();
        }

        public IColor this[string name]
        {
            get
            {
                return colors[name];
            }
            set
            {
                colors.Add(name, value);
            }
        }
    }
}