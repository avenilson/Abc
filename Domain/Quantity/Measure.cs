using Abc.Data.Quantity;
using Abc.Domain.Common;

namespace Abc.Domain.Quantity
{
    public class Measure: Entity<MeasureData>//veab andmeid andmebaasi ja kasutajaliidese kihi vahel
    {
        public Measure(MeasureData data) : base(data)
        {
        }
    }
}
