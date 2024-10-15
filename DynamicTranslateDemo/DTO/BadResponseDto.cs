//using DynamicTranslate.Attribute;
using DynamicTranslate.Attribute;
using System.Text.Json.Serialization;

namespace DynamicTranslateDemo.DTO
{
    public class BadResponseDto
    {
        [JsonIgnore]
        public string key { get; set; }

        [Translate(nameof(key))]
        public string Message { get; set; }
    }
}
