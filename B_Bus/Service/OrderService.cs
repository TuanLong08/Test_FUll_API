using A_DaTa.Context;
using A_DaTa.Models;
using B_Bus.Respositories;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Service
{
    public class OrderService : IOrderRes
    {
        private MyDBContext _context;

        public OrderService(MyDBContext context)
        {
            _context = context;
        }
        public OrderDTO AddOrder(OrderDTO orderDTO)
        {
            var _order = new Order
            {
                Customername = orderDTO.Customername,
                Address = orderDTO.Address,
                PhoneNumber = orderDTO.PhoneNumber,
                TotalAmount = orderDTO.TotalAmount,
                Status = orderDTO.Status,
                IsDeleted = orderDTO.IsDeleted,
                CreatedAt = orderDTO.CreatedAt,
                UpdatedAt = orderDTO.UpdatedAt

            };
            _context.Add(_order);
            _context.SaveChanges();
            return new OrderDTO
            {
                Id = _order.Id,
                Customername = _order.Customername,
                Address = _order.Address,
                PhoneNumber = _order.PhoneNumber,
                TotalAmount = _order.TotalAmount,
                Status = _order.Status,
                IsDeleted = _order.IsDeleted,
                CreatedAt = _order.CreatedAt,
                UpdatedAt = _order.UpdatedAt,
            };
        }

        public void deleteOrder(Guid id)
        {
            var _order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (_order != null)
            {
                _context.Orders.Remove(_order);
                _context.SaveChanges();
            }
        }

        public List<OrderDTO> GetAll()
        {
            var _order = _context.Orders.Select(c => new OrderDTO
            {
                Id = c.Id,
                Customername = c.Customername,
                Address = c.Address,
                PhoneNumber= c.PhoneNumber,
                TotalAmount= c.TotalAmount,
                Status = c.Status,
                IsDeleted = c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
            return _order.ToList();
        }

        public OrderDTO GetOrderById(Guid id)
        {
            var _order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (_order != null)
            {
                return new OrderDTO
                {
                    Id = _order.Id,
                    Customername = _order.Customername,
                    Address = _order.Address,
                    PhoneNumber = _order.PhoneNumber,
                    TotalAmount = _order.TotalAmount,
                    Status = _order.Status,
                    IsDeleted = _order.IsDeleted,
                    CreatedAt = _order.CreatedAt,
                    UpdatedAt = _order.UpdatedAt
                };
            }
            return null;
        }

        public void updateOrder(OrderDTO orderDTO)
        {
            var _order = _context.Orders.SingleOrDefault(c => c.Id == orderDTO.Id);
            _order.Id = orderDTO.Id;
            _order.Customername = orderDTO.Customername;
            _order.Address = orderDTO.Address;
            _order.PhoneNumber = orderDTO.PhoneNumber;
            _order.TotalAmount = orderDTO.TotalAmount;
            _order.Status = orderDTO.Status;
            _order.IsDeleted = orderDTO.IsDeleted;
            _order.CreatedAt = orderDTO.CreatedAt;
            _order.UpdatedAt = orderDTO.UpdatedAt;
            _context.SaveChanges();
        }
    }
}
