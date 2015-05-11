using SpecUI.Specs;

namespace SpecUI.Models
{
    public class Shipment
    {
        public string Title { get; set; }
        public int WeightPounds { get; set; }
        public decimal InsuranceAmount { get; set; }
        public LocationType LocationType { get; set; }
        public ContainerType ContainerType { get; set; }
        public bool IsPerishable { get; set; }
    }
}
