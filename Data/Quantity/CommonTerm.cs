using Abc.Data.Common;

namespace Abc.Data.Quantity
{
    public class CommonTerm: PeriodData
    {
        public string MasterId { get; set; }
        public string TermId { get; set; }
        public int Power { get; set; }
    }
}
