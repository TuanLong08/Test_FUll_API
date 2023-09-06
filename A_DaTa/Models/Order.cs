using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DaTa.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string Customername { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<OrderDetail> orderDetails { get; set; }
    }
}
