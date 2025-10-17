using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi.core
{
    public class Order
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public int Quantity { get; set; }
        public string? DateOrder { get; set; }
        public string? ArriveDate { get; set; }
        public int? PickUpPointId { get; set; }
        public int? UserId { get; set; }
        public string? CodeToConfirmOrder { get; set; }
        public string? Status { get; set; }

        public Guid OrderGroupId { get; set; }
        public int OrderNumber { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual PickUpPoint PickUpPoint { get; set; }
    }
}
