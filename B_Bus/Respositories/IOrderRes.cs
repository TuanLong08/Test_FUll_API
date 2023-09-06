using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Respositories
{
    public interface IOrderRes
    {
        List<OrderDTO> GetAll();
        OrderDTO GetOrderById(Guid id);
        OrderDTO AddOrder(OrderDTO orderDTO);
        void updateOrder(OrderDTO orderDTO);
        void deleteOrder(Guid id);
    }
}
