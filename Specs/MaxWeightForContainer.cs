using System.Collections.Generic;
using System.Linq;
using SpecUI.Attributes;
using SpecUI.Extensions;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment id at or below a max weight, if it has one of the specified container types")]
    public class MaxWeightForContainer : BaseShipmentSpec
    {
        [Description("The container types that impose a max weight on the shipment")]
        public IEnumerable<ContainerType> ContainerTypes { get; set; }

        [Description("The max weight, if one of the specified container types is being used")]
        public int MaxWeightPerUnit { get; set; }

        public override bool IsSatisfied(Shipment shipment)
        {
            if (!ContainerTypes.ToList().Contains(shipment.ContainerType))
            {
                return true;
            }
            return shipment.WeightPounds <= MaxWeightPerUnit;
        }

        public override IEnumerable<IValidationError> IsValid()
        {
            if (ContainerTypes.IsNullOrEmpty())
            {
                yield return new ValidationError(
                    "You must specify at least one container type");
            }

            if (MaxWeightPerUnit <= 0)
            {
                yield return new ValidationError(
                    "MaxWeightPerUnit must be greater than zero",
                    criterionName: () => MaxWeightPerUnit);
            }
        }
    }
}