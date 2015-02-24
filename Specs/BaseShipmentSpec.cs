using System.Collections.Generic;
using SpecUI.Models;

namespace SpecUI.Specs
{
    public abstract class BaseShipmentSpec : IShipmentSpec
    {
        public abstract bool IsSatisfied(Shipment shipment);
        public abstract IEnumerable<IValidationError> IsValid();
    }
}