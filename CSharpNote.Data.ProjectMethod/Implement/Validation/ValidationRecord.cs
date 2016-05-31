namespace CSharpNote.Data.Project.Implement.Validation
{
    public class ValidationRecord
    {
        public string Notification { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public RuleTitle Type { get; set; }
        public bool IsReverse { get; set; }
        public bool IsReturn { get; set; }
    }
}