namespace DynamicTranslateDemo.Model
{
    public class ChildLookup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Property1 { get; set; }
        public int? Property2 { get; set; }
        public bool? Property3 { get; set; }


        public int MasterLookupId { get; set; }
        public MasterLookup MasterLookup { get; set; }
    }
}
