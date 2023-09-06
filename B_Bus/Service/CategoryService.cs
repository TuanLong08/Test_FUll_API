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
    public class CategoryService : ICategoryRes
    {
        private MyDBContext _context;

        public CategoryService(MyDBContext context)
        {
            _context = context;
        }
        public CategoryDTO AddCategory(CategoryDTO categoryDTO)
        {
            var _category = new Category
            {
                Name = categoryDTO.Name,
                IsDeleted = categoryDTO.IsDeleted,
                CreatedAt = categoryDTO.CreatedAt,
                UpdateAt = categoryDTO.UpdateAt
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryDTO
            {
                Id = _category.Id,
                Name = _category.Name,
                IsDeleted = _category.IsDeleted,
                CreatedAt = _category.CreatedAt,
                UpdateAt = _category.UpdateAt
            };
        }

        public void deleteCategory(Guid id)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (_category != null)
            {
                _context.Categories.Remove(_category);
                _context.SaveChanges();
            }
        }

        public List<CategoryDTO> GetAll()
        {
            var _category = _context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                IsDeleted = c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdateAt = c.UpdateAt
            });
            return _category.ToList();
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (_category != null)
            {
                return new CategoryDTO
                {
                    Id = _category.Id,
                    Name = _category.Name,
                    IsDeleted = _category.IsDeleted,
                    CreatedAt = _category.CreatedAt,
                    UpdateAt = _category.UpdateAt
                };
            }
            return null;
        }

        public void updateCategory(CategoryDTO categoryDTO)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.Id == categoryDTO.Id);
            _category.Id = categoryDTO.Id;
             _category.Name = categoryDTO.Name;
            _category.IsDeleted = categoryDTO.IsDeleted;
            _category.CreatedAt = categoryDTO.CreatedAt;
            _category.UpdateAt = categoryDTO.UpdateAt;
            _context.SaveChanges();
        }
    }
}
