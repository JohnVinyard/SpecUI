using System.Collections.Generic;

namespace SpecUI.Models
{
    public class CriterionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public int? ErrorIndex { get; set; }
        public object Value { get; set; }
        public JavascriptType Type { get; set; }
        public IEnumerable<object> Options { get; set; }
        public bool IsArray { get; set; }
    }
}