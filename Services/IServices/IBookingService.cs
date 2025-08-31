using AdvFullstack_Labb1.Models.DTOs.Booking;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllAsync();
        Task<BookingDto> GetByIdAsync(int bookingId);
        Task<int> CreateAsync(BookingCreateDto newBooking);
        Task<bool> UpdateAsync(BookingDto booking);
        Task<bool> PatchAsync(int id, BookingPatchDto patchBooking);
        Task<bool> DeleteAsync(int bookingId);
    }
}
