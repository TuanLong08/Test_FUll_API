using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string Customername { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
