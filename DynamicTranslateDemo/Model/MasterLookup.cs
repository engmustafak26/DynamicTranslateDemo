namespace DynamicTranslateDemo.Model
{
    public class MasterLookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Property1 { get; set; }
        public int? Property2 { get; set; }
        public bool? Property3 { get; set; }


        public ICollection<ChildLookup> ChildLookups { get; set; }
    }
}
