using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.idal
{
    public interface Ijewelry
    {
        Task<List<Models.Jewelry>> GetAllJewelry();
        Task<Models.Jewelry> GetJewelryById(int jewelryCode);
        Task AddJewelry(Models.Jewelry jewelry);
        Task UpdateJewelry(Models.Jewelry jewelry);
        Task DeleteJewelry(int jewelryCode);

    }
}
