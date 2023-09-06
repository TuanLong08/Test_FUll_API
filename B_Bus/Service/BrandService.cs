using A_DaTa.Context;
using A_DaTa.Models;
using B_Bus.Respositories;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;

namespace B_Bus.Service
{
    public class BrandService : IBrandRes
    {
        private MyDBContext _context;

        public BrandService(MyDBContext context)
        {
            _context = context;
        }
        public BrandDTO AddBrand(BrandDTO brandDTO)
        {
            var _brand = new Brand
            {
                Name = brandDTO.Name,
                IsDeleted = brandDTO.IsDeleted,
                CreatedAt = brandDTO.CreatedAt,
                UpdateAt = brandDTO.UpdateAt
            };
            _context.Add(_brand);
            _context.SaveChanges();
            return new BrandDTO
            {
                Id = _brand.Id,
                Name = _brand.Name,
                IsDeleted = _brand.IsDeleted,
                CreatedAt = _brand.CreatedAt,
                UpdateAt= _brand.UpdateAt
            };
        }

        public void deleteBrand(Guid id)
        {
            var _brand = _context.Brands.SingleOrDefault(c => c.Id == id);
            if (_brand != null)
            {
                _context.Brands.Remove(_brand);
                _context.SaveChanges();
            }
        }

        public List<BrandDTO> GetAll()
        {
            var brand = _context.Brands.Select(c => new BrandDTO
            {
                Id = c.Id,
                Name = c.Name,
                IsDeleted= c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdateAt = c.UpdateAt
            });
            return brand.ToList();
        }

        public BrandDTO GetBrandById(Guid id)
        {
            var brand = _context.Brands.SingleOrDefault(c => c.Id == id);
            if (brand != null) 
            {
                return new BrandDTO
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    IsDeleted = brand.IsDeleted,
                    CreatedAt = brand.CreatedAt,
                    UpdateAt = brand.UpdateAt
                };
            }
            return null;
        }

        public void updateBrand(BrandDTO brandDTO)
        {
            var _brand = _context.Brands.SingleOrDefault(c => c.Id == brandDTO.Id);
            _brand.Id = brandDTO.Id;
            _brand.Name = brandDTO.Name;
            _brand.IsDeleted = brandDTO.IsDeleted;
            _brand.CreatedAt = brandDTO.CreatedAt;
            _brand.UpdateAt = brandDTO.UpdateAt;
            _context.SaveChanges();
        }
    }
}
