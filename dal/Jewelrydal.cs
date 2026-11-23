using dal.Data;
using dal.idal;
using Microsoft.EntityFrameworkCore;

namespace dal
{
    public class Jewelrydal : Ijewelry
    {
        private readonly AppDbContext _context;

        public Jewelrydal(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.Jewelry>> GetAllJewelry()
        {
           var jewelryList = _context.Jewelries.Include(j=>j.CategoryCodeNavigation).ToList();
           return await Task.FromResult(jewelryList);
        }
      public async Task<Models.Jewelry> GetJewelryById(int jewelryCode)
        {
           var jewelry = _context.Jewelries.FirstOrDefaultAsync(j => j.JewelryCode == jewelryCode);
           return await jewelry;
            
        }
      public async Task AddJewelry(Models.Jewelry jewelry)
        {
            var existingJewelry = _context.Jewelries.FirstOrDefault(j => j.JewelryCode == jewelry.JewelryCode);
            if (existingJewelry != null)
            {
                throw new Exception("Jewelry with the same code already exists.");
            }
            _context.Jewelries.Add(jewelry);
            await _context.SaveChangesAsync();
        }
      public async Task UpdateJewelry(Models.Jewelry jewelry)
        {
            var existingJewelry = _context.Jewelries.FirstOrDefault(j => j.JewelryCode == jewelry.JewelryCode);
            if (existingJewelry == null)
            {
                throw new Exception("Jewelry not found.");
            }
            existingJewelry.JewelryName = jewelry.JewelryName;
            existingJewelry.CategoryCode = jewelry.CategoryCode;
            existingJewelry.MaterialCode = jewelry.MaterialCode;
            existingJewelry.Price = jewelry.Price;
            existingJewelry.DiscountPercent = jewelry.DiscountPercent;
            existingJewelry.Description = jewelry.Description;
            existingJewelry.ImageUrl = jewelry.ImageUrl;
            await _context.SaveChangesAsync();
        }
      public async Task DeleteJewelry(int jewelryCode)
        {
            var existingJewelry = _context.Jewelries.FirstOrDefault(j => j.JewelryCode == jewelryCode);
            if (existingJewelry == null)
            {
                throw new Exception("Jewelry not found.");
            }
            _context.Jewelries.Remove(existingJewelry);
            await _context.SaveChangesAsync();
        }


    }
}
