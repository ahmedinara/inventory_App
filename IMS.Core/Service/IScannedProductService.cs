using IMS.Core.Dtos;
using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IScannedProductService
    {
        Task<ResponseResult> AddScannedItems(List<ItemScannedModel> itemScannedModels, int userId);
        Task<RfIdScannedProduct> GetRfIdScannedProductById(int id);
        Task<IEnumerable<RfIdScannedProduct>> GetRfIdScannedProducts();

    }
}
