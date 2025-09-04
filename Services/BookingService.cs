using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.DTOs.Booking;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;
using AdvFullstack_Labb1.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Services
{
    public class BookingService : IBookingService
    {
        private const int bookingDurationInHours = 2; // Hours
        
        private readonly IBookingRepository _repo;
        private readonly ICustomerRepository _customerRepo;
        private readonly ITableRepository _tableRepo;
        private readonly MyCafeLabb1Context _context;
        public BookingService(
            IBookingRepository repo,
            ICustomerRepository customerRepo,
            ITableRepository tableRepo,
            MyCafeLabb1Context context)
        {
            _repo = repo;
            _customerRepo = customerRepo;
            _tableRepo = tableRepo;
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
            var roundedStartTime = BookingHelper.RoundStartTime(newBooking.StartTime);

            var booking = new Booking
            {
                CustomerAmount = newBooking.CustomerAmount,
                StartTime = roundedStartTime,
                EndTime = roundedStartTime.AddHours(bookingDurationInHours),
                CustomerId = newBooking.CustomerId,
                TableId = newBooking.TableId
            };

            var newBookingId = await _repo.CreateAsync(booking);

            return newBookingId;
        }

        public async Task<bool> TryCreateBookingAsync(BookingRequestDto requestDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var roundedStartTime = BookingHelper.RoundStartTime(requestDto.StartTime);

            bool isStillAvailable = await _tableRepo
                .IsAvailableAsync(
                    requestDto.TableId, 
                    roundedStartTime);
                
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
                StartTime = roundedStartTime,
                EndTime = roundedStartTime.AddHours(bookingDurationInHours),
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

            var roundedStartTime = BookingHelper.RoundStartTime(booking.StartTime);

            existingBooking.StartTime = roundedStartTime;
            existingBooking.EndTime = roundedStartTime.AddHours(bookingDurationInHours);
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
            {
                var roundedStartTime = BookingHelper.RoundStartTime(patchBooking.StartTime.Value);

                existingBooking.StartTime = roundedStartTime;
                existingBooking.EndTime = roundedStartTime.AddHours(bookingDurationInHours);
            }

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
    }
}
