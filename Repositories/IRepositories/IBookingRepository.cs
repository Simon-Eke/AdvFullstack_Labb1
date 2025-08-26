using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int bookingId);
        Task<int> CreateAsync(Booking newBooking);
        Task<bool> UpdateAsync(Booking booking);
        Task<bool> PatchAsync(Booking booking);
        Task<bool> DeleteAsync(int bookingId);
    }
}
