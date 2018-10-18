using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4
{
    public class Loot
    {
        public long Weight;
        public long Value;
        public long UnitValue
        {
            get { return (Value / Weight); }
            set { }
        }

        public Loot (long weight, long value)
        {
            this.Weight = weight;
            this.Value = value;
        }

        
    }
}
