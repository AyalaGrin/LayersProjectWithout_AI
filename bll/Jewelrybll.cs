using dal;
using dal.idal;
using dal.Models;
using dto;
using ibll;
using System;

namespace bll
{
    public class Jewelrybll: IJewelry
    {
        private readonly Ijewelry _jewelrydal;
        public Jewelrybll(Ijewelry jewelrydal)
        {
            _jewelrydal = jewelrydal;
        }
        public async Task<List<Jewelrydto>> GetAllJewelryAsync()
        {
            var daljewelryList = await _jewelrydal.GetAllJewelry();
            
            var dtoJewelryList = daljewelryList.Select(j=> new Jewelrydto
            {
                JewelryCode = j.JewelryCode,
                JewelryName = j.JewelryName,
                CategoryCode = j.CategoryCode,
                MaterialCode = j.MaterialCode,
                Price = j.Price,
                DiscountPercent = j.DiscountPercent,
                Description = j.Description,
                ImageUrl = j.ImageUrl,
                CategoryName = j.CategoryCodeNavigation?.CategoryName
            }
            ).ToList();

            return dtoJewelryList;
        }
        public async Task<Jewelrydto> GetJewelryByIdAsync(int jewelryCode)
        {
            var daljewelry = await _jewelrydal.GetJewelryById(jewelryCode);
            if (daljewelry == null)
                return null;
            

            var dtoJewelry = new Jewelrydto
            {
                JewelryCode = daljewelry.JewelryCode,
                JewelryName = daljewelry.JewelryName,
                CategoryCode = daljewelry.CategoryCode,
                MaterialCode = daljewelry.MaterialCode,
                Price = daljewelry.Price,
                DiscountPercent = daljewelry.DiscountPercent,
                Description = daljewelry.Description,
                ImageUrl = daljewelry.ImageUrl,
                CategoryName = daljewelry.CategoryCodeNavigation?.CategoryName
            };
            return dtoJewelry;
        }
        public async Task AddJewelryAsync(Jewelrydto jewelry)
        {
            if (jewelry.Price <= 0)
            {
                throw new Exception("מחיר התכשיט חייב להיות גדול מאפס.");
            }
            if (jewelry.DiscountPercent < 0 || jewelry.DiscountPercent > 100)
            {
                throw new Exception("אחוז הנחה חייב להיות בין 0 ל-100.");
            }

            var daljewelry = new Jewelry
            {
                JewelryCode = jewelry.JewelryCode,
                JewelryName = jewelry.JewelryName,
                CategoryCode = jewelry.CategoryCode,
                MaterialCode = jewelry.MaterialCode,
                Price = jewelry.Price,
                DiscountPercent = jewelry.DiscountPercent,
                Description = jewelry.Description,
                ImageUrl = jewelry.ImageUrl,
            };
            await _jewelrydal.AddJewelry(daljewelry);
        }
        public async Task UpdateJewelryAsync(Jewelrydto jewelry)
        {
            if (jewelry.Price <= 0)
            {
                throw new Exception("מחיר התכשיט חייב להיות גדול מאפס.");
            }
            if (jewelry.DiscountPercent < 0 || jewelry.DiscountPercent > 100)
            {
                throw new Exception("אחוז הנחה חייב להיות בין 0 ל-100.");
            }

            var daljewelry = new Jewelry
            {
                JewelryCode = jewelry.JewelryCode,
                JewelryName = jewelry.JewelryName,
                CategoryCode = jewelry.CategoryCode,
                MaterialCode = jewelry.MaterialCode,
                Price = jewelry.Price,
                DiscountPercent = jewelry.DiscountPercent,
                Description = jewelry.Description,
                ImageUrl = jewelry.ImageUrl
            };
            await _jewelrydal.UpdateJewelry(daljewelry);           
        }
        public async Task DeleteJewelryAsync(int jewelryCode)
        {
            await _jewelrydal.DeleteJewelry(jewelryCode);
        }

    }
}
