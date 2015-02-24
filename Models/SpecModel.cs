using System.Collections.Generic;

namespace SpecUI.Models
{
    public class SpecModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<CriterionModel> Criteria { get; set; }
    }
}