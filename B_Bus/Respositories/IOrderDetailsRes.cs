using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Respositories
{
    public interface IOrderDetailsRes
    {
        List<OrderDetailDTO> GetAll();
        OrderDetailDTO GetOrderDetailById(Guid id);
        OrderDetailDTO AddOrderDetail(OrderDetailDTO orderDetailDTO);
        void updateOrderDetail(OrderDetailDTO orderDetailDTO);
        void deleteOrderDetail(Guid id);
    }
}
