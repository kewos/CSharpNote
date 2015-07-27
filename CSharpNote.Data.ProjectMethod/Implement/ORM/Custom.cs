using System;

namespace CSharpNote.Data.Project.Implement.ORM
{
    public enum Level
    {
        Vip,
        Normal
    }

    public class Custom : MappingModelBase
    {
        public Custom()
        {
            SetMapping("TestDBColumn", "Test");
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
        public bool Test { get; set; }
        public bool? TestNullable { get; set; }
        public float? Money { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? MondifyOn { get; set; }
        public Level Level { get; set; }
    }
}