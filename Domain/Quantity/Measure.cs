using Abc.Data.Quantity;
using Abc.Domain.Common;

namespace Abc.Domain.Quantity
{
    public sealed class Measure: Entity<MeasureData>  //veab andmeid andmebaasi ja kasutajaliidese kihi vahel
    {
        public Measure(): this(null) { }
        public Measure(MeasureData data) : base(data) { }
    }
}
