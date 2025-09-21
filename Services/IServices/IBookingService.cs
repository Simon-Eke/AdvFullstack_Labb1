using AdvFullstack_Labb1.Models.DTOs.Booking;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllAsync();
        Task<List<BookingWithDetailsDto>> GetAllWithDetailsAsync();
        Task<BookingDto> GetByIdAsync(int bookingId);
        Task<BookingWithDetailsDto> GetByIdWithDetailsAsync(int bookingId);
        Task<bool> TryCreateBookingAsync(BookingRequestDto requestDto);
        Task<bool> TryUpdateBookingAsync(BookingUpdateRequestDto booking);
        Task<bool> PatchAsync(int id, BookingPatchDto patchBooking);
        Task<bool> DeleteAsync(int bookingId);
    }
}
