using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Bus.Respositories
{
    public interface IBrandRes
    {
        List<BrandDTO> GetAll();
        BrandDTO GetBrandById(Guid id);
        BrandDTO AddBrand(BrandDTO brandDTO);
        void updateBrand(BrandDTO brandDTO);
        void deleteBrand(Guid id);
    }
}
