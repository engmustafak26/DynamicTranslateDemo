using DynamicTranslate.Attribute;
using DynamicTranslateDemo.Model;

namespace DynamicTranslateDemo.DTO
{
    public class MasterLookupDto
    {
        public int Id { get; set; }

        [Translate(nameof(MasterLookup),nameof(MasterLookup.Name),nameof(Id))]
        public string Name { get; set; }

        public ChildLookupDto[]  ChildLookups { get; set; }
    }

    public class ChildLookupDto
    {
        public int Id { get; set; }

        [Translate(nameof(ChildLookup), nameof(ChildLookup.Name), nameof(Id))]

        public string Name { get; set; }
    }
}
