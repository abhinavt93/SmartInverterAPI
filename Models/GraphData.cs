using System;
using System.Collections.Generic;

namespace SmartInverterAPI.Models
{
    public class GraphData
    {
        public int CustomerID { get; set; }

        public List<Decimal> DataMain { get; set; }

        public List<String> Label { get; set; }

        public String TitleMain { get; set; }

        public List<Decimal> DataSecondary { get; set; }

        public String TitleSecondary { get; set; }
    }
}
