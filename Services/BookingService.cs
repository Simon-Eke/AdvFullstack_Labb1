namespace AdvFullstack_Labb1.Services
{
    public class BookingService
    {
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
