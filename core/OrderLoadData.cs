using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi.core
{
    public class OrderLoadData
    {
        public int OrderId { get; set; }
        public string Article {  get; set; }    
        public string Status { get; set; }
        public string Address { get; set; }
        public string DateOrder { get; set; }
        public string ArriveDate { get; set; }
        public virtual Order Order { get; set; }
    }
}
