using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;
using GigGuide.Data.Repository.Interfaces;

namespace GigGuide.Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public BookingRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(int id)
        {
            return await DbContext.Bookings.FindAsync(id) != null;
        }
        public async Task<Booking?> Find(int id)
        {
            return await DbContext.Bookings.FindAsync(id);
            //return await DbContext.Bookings.FirstOrDefaultAsync(item => item.ID == id);
        }
        public void Update(Booking booking)
        {
            Booking? existingBooking = DbContext.Bookings.Find(booking.Id);
            if (existingBooking is not null)
            {
                existingBooking.Quantity = booking.Quantity;
                existingBooking.PerformanceId = booking.PerformanceId;
                existingBooking.CustomerId = booking.CustomerId;

                DbContext.Bookings.Update(existingBooking);
            }
        }
        public void Delete(int id)
        {
            Booking? booking = DbContext.Bookings.Find(id);
            if (booking is not null)
                DbContext.Bookings.Remove(booking);
        }
    }
}
