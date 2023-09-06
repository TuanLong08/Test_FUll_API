using A_DaTa.Context;
using A_DaTa.Models;
using B_Bus.Respositories;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Service
{
    public class OrderDetailsService : IOrderDetailsRes
    {
        private MyDBContext _context;

        public OrderDetailsService(MyDBContext context)
        {
            _context = context;
        }
        public OrderDetailDTO AddOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var _order = new OrderDetail
            {
                Id = orderDetailDTO.Id,
                ProductId = orderDetailDTO.ProductId,
                OrderID = orderDetailDTO.OrderID,
                Quantity = orderDetailDTO.Quantity,
                Price = orderDetailDTO.Price,
                IsDeleted = orderDetailDTO.IsDeleted,
                CreatedAt = orderDetailDTO.CreatedAt,
                UpdatedAt = orderDetailDTO.UpdatedAt,
            };
            _context.Add(_order);
            _context.SaveChanges();
            return new OrderDetailDTO
            {
                Id = _order.Id,
                ProductId = _order.ProductId,
                OrderID = _order.OrderID,
                Quantity = _order.Quantity,
                Price = _order.Price,
                IsDeleted = _order.IsDeleted,
                CreatedAt = _order.CreatedAt,
                UpdatedAt = _order.UpdatedAt,
            };
        }

        public void deleteOrderDetail(Guid id)
        {
            var _order = _context.OrderDetails.SingleOrDefault(c => c.Id == id);
            if (_order != null)
            {
                _context.OrderDetails.Remove(_order);
                _context.SaveChanges();
            }
        }

        public List<OrderDetailDTO> GetAll()
        {
            var _order = _context.OrderDetails.Select(c => new OrderDetailDTO
            {
                Id = c.Id,
                ProductId = c.ProductId,
                OrderID = c.OrderID,
                Quantity = c.Quantity,
                Price = c.Price,
                IsDeleted = c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
            });
            return _order.ToList();
        }

        public OrderDetailDTO GetOrderDetailById(Guid id)
        {
            var _order = _context.OrderDetails.SingleOrDefault(c => c.Id == id);
            if (_order != null)
            {
                return new OrderDetailDTO
                {
                    Id = _order.Id,
                    ProductId = _order.ProductId,
                    OrderID = _order.OrderID,
                    Quantity = _order.Quantity,
                    Price = _order.Price,
                    IsDeleted = _order.IsDeleted,
                    CreatedAt = _order.CreatedAt,
                    UpdatedAt = _order.UpdatedAt,
                };
            }
            return null;
        }

        public void updateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var _order = _context.OrderDetails.SingleOrDefault(c => c.Id == orderDetailDTO.Id);
            _order.Id = orderDetailDTO.Id;
            _order.ProductId = orderDetailDTO.ProductId;
            _order.OrderID = orderDetailDTO.OrderID;
            _order.Quantity = orderDetailDTO.Quantity;
            _order.Price = orderDetailDTO.Price;
            _order.IsDeleted = orderDetailDTO.IsDeleted;
            _order.CreatedAt = orderDetailDTO.CreatedAt;
            _order.UpdatedAt = orderDetailDTO.UpdatedAt;
            _context.SaveChanges();
        }
    }
}
