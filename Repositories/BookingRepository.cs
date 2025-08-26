using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;

namespace AdvFullstack_Labb1.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MyCafeLabb1Context _context;

        public BookingRepository(MyCafeLabb1Context context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Booking newBooking)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> GetByIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PatchAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
