using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Respositories
{
    public interface ICategoryRes
    {
        List<CategoryDTO> GetAll();
        CategoryDTO GetCategoryById(Guid id);
        CategoryDTO AddCategory(CategoryDTO categoryDTO);
        void updateCategory(CategoryDTO categoryDTO);
        void deleteCategory(Guid id);
    }
}
