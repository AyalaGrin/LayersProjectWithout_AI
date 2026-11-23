using dto;

namespace ibll
{
    public interface IJewelry
    {
        Task<List<Jewelrydto>> GetAllJewelryAsync();
        Task<Jewelrydto> GetJewelryByIdAsync(int jewelryCode);
        Task AddJewelryAsync(Jewelrydto jewelry);
        Task UpdateJewelryAsync(Jewelrydto jewelry);
        Task DeleteJewelryAsync(int jewelryCode);
    }
}
