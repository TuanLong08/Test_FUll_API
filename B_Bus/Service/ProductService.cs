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
using System.Xml.Linq;

namespace B_Bus.Service
{
    public class ProductService : IProDuctRes
    {
        private MyDBContext _context;

        public ProductService(MyDBContext context)
        {
            _context = context;
        }
        public ProductDTO AddProduct(ProductDTO productDTO)
        {
            var _product = new ProDuct
            {
                Id = productDTO.Id,
                CategoryId = productDTO.CategoryId,
                BrandID = productDTO.BrandID,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                IsDeleted = productDTO.IsDeleted,
                CreatedAt = productDTO.CreatedAt,
                UpdatedAt = productDTO.UpdatedAt,
            };
            _context.Add(_product);
            _context.SaveChanges();
            return new ProductDTO
            {
                Id = _product.Id,
                CategoryId = _product.CategoryId,
                BrandID = _product.BrandID,
                Name = _product.Name,
                Price = _product.Price,
                Description = _product.Description,
                IsDeleted = _product.IsDeleted,
                CreatedAt = _product.CreatedAt,
                UpdatedAt = _product.UpdatedAt,
            };
        }

        public void deleteProduct(Guid id)
        {
            var _product = _context.ProDucts.SingleOrDefault(c => c.Id == id);
            if (_product != null)
            {
                _context.ProDucts.Remove(_product);
                _context.SaveChanges();
            }
        }

        public List<ProductDTO> GetAll()
        {
            var _product = _context.ProDucts.Select(c => new ProductDTO
            {
                Id = c.Id,
                CategoryId = c.CategoryId,
                BrandID = c.BrandID,
                Name = c.Name,
                Price = c.Price,
                Description = c.Description,
                IsDeleted = c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
            });
            return _product.ToList();
        }

        public ProductDTO GetProductById(Guid id)
        {
            var _product = _context.ProDucts.SingleOrDefault(c => c.Id == id);
            if (_product != null)
            {
                return new ProductDTO
                {
                    Id = _product.Id,
                    CategoryId = _product.CategoryId,
                    BrandID = _product.BrandID,
                    Name = _product.Name,
                    Price = _product.Price,
                    Description = _product.Description,
                    IsDeleted = _product.IsDeleted,
                    CreatedAt = _product.CreatedAt,
                    UpdatedAt = _product.UpdatedAt,
                };
            }
            return null;
        }

        public void updateProduct(ProductDTO productDTO)
        {
            var _product = _context.ProDucts.SingleOrDefault(c => c.Id == productDTO.Id);
            _product.Id = productDTO.Id;
            _product.CategoryId = productDTO.CategoryId;
            _product.BrandID = productDTO.BrandID;
            _product.Name = productDTO.Name;
            _product.Price = productDTO.Price;
            _product.Description = productDTO.Description;
            _product.IsDeleted = productDTO.IsDeleted;
            _product.CreatedAt = productDTO.CreatedAt;
            _product.UpdatedAt = productDTO.UpdatedAt;
            _context.SaveChanges();
        }
    }
}
