using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Respositories
{
    public interface IProDuctRes
    {
        List<ProductDTO> GetAll();
        ProductDTO GetProductById(Guid id);
        ProductDTO AddProduct(ProductDTO productDTO);
        void updateProduct(ProductDTO productDTO);
        void deleteProduct(Guid id);
    }
}
