using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.DTOs.Booking;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;
        private readonly ICustomerRepository _customerRepo;
        private readonly ITableRepository _tableRepo;
        private readonly MyCafeLabb1Context _context;
        public BookingService(IBookingRepository repo, MyCafeLabb1Context context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            var bookings = await _repo.GetAllAsync();

            var bookingDtoList = bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                CustomerAmount = b.CustomerAmount,
                StartTime = b.StartTime,
                CustomerId = b.CustomerId,
                TableId = b.TableId
            }).ToList();

            return bookingDtoList;
        }

        public async Task<BookingDto> GetByIdAsync(int bookingId)
        {
            var booking = await _repo.GetByIdAsync(bookingId);

            if (booking == null)
                return null;

            var bookingDto = new BookingDto
            {
                Id = booking.Id,
                CustomerAmount = booking.CustomerAmount,
                StartTime = booking.StartTime,
                CustomerId = booking.CustomerId,
                TableId = booking.TableId
            };

            return bookingDto;
        }
        public async Task<int> CreateAsync(BookingCreateDto newBooking)
        {
            var booking = new Booking
            {
                CustomerAmount = newBooking.CustomerAmount,
                StartTime = newBooking.StartTime,
                CustomerId = newBooking.CustomerId,
                TableId = newBooking.TableId
            };

            var newBookingId = await _repo.CreateAsync(booking);

            return newBookingId;
        }

        public async Task<bool> TryCreateBookingAsync(BookingRequestDto requestDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            bool isStillAvailable = await _tableRepo
                .IsAvailableAsync(
                    requestDto.TableId, 
                    requestDto.StartTime);
                
            if (!isStillAvailable)
                return false;

            var existingCustomer = await _customerRepo
                .GetByNameAndPhoneAsync(
                    requestDto.Name, 
                    requestDto.PhoneNumber);

            int customerId;

            if (existingCustomer == null)
            {
                var customer = new Customer
                {
                    Name = requestDto.Name,
                    PhoneNumber = requestDto.PhoneNumber
                };

                customerId = await _customerRepo.CreateAsync(customer);
            }
            else
            {
                customerId = existingCustomer.Id;
            }

            var newBooking = new Booking
            {
                StartTime = requestDto.StartTime,
                CustomerAmount = requestDto.CustomerAmount,
                TableId = requestDto.TableId,
                CustomerId = customerId
            };

            await _repo.CreateAsync(newBooking);
            await transaction.CommitAsync();

            return true;
        }
        public async Task<bool> UpdateAsync(BookingDto booking)
        {
            var existingBooking = await _repo.GetByIdAsync(booking.Id);
            if (existingBooking == null)
                return false;

            existingBooking.StartTime = booking.StartTime;
            existingBooking.CustomerAmount = booking.CustomerAmount;
            existingBooking.CustomerId = booking.CustomerId;
            existingBooking.TableId = booking.TableId;


            await _repo.UpdateAsync(existingBooking);

            return true;
        }
        public async Task<bool> PatchAsync(int id, BookingPatchDto patchBooking)
        {
            var existingBooking = await _repo.GetByIdAsync(id);
            if (existingBooking == null)
                return false;

            if (patchBooking.StartTime.HasValue)
                existingBooking.StartTime = patchBooking.StartTime.Value;

            if (patchBooking.CustomerAmount.HasValue)
                existingBooking.CustomerAmount = patchBooking.CustomerAmount.Value;

            if (patchBooking.TableId.HasValue) 
                existingBooking.TableId = patchBooking.TableId.Value;

            if (patchBooking.CustomerId.HasValue)
                existingBooking.CustomerId = patchBooking.CustomerId.Value;

            var success = await _repo.UpdateAsync(existingBooking);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteAsync(int bookingId)
        {
            var existingBooking = await _repo.GetByIdAsync(bookingId);
            if (existingBooking == null)
                return false;

            var success = await _repo.DeleteAsync(bookingId);
            if (success != true)
                return false;

            return true;
        }
        /*
            using var transaction = await _context.Database.BeginTransactionAsync();

            bool isStillAvailable = await _context.Tables
                .Where(t => t.Id == requestedTableId)
                .Where(t => t.Bookings.All(b =>
                    b.StartTime >= desiredEndTime || b.EndTime <= desiredStartTime))
                .AnyAsync();

            if (!isStillAvailable)
                return false;

            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
         
         
         */
    }
}
