using System.Collections.Generic;

namespace SpecUI.Models
{
    public class OutputModel
    {
        public IEnumerable<SpecModel> Specs { get; set; }
        public IEnumerable<SpecModel> Metadata { get; set; }
    }
}