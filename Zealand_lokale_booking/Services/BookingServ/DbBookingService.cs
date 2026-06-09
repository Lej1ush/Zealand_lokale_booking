using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;
using Zealand_lokale_booking.Repositories.UserRep;

namespace Zealand_lokale_booking.Services.BookingServ
{
    public class DbBookingService : IBookingService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly RoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public string ErrorMessage { get; private set; } = "";

        public DbBookingService(
            BookingRepository bookingRepository,
            RoomRepository roomRepository,
            IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.FindByIdAsync(id);
        }

        public async Task<List<Booking>> GetBookingsByUserAsync(int userId)
        {
            return await _bookingRepository.FindByUserAsync(userId);
        }

        public async Task<Booking?> CreateBookingAsync(
            int userId,
            int roomId,
            DateTime startTime,
            DateTime endTime,
            int? bookingPartId)
        {
            ErrorMessage = "";

            var room = await _roomRepository.GetByIdAsync(roomId);

            if (room == null)
            {
                ErrorMessage = "Lokalet findes ikke.";
                return null;
            }

            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                ErrorMessage = "Brugeren findes ikke.";
                return null;
            }

            if (endTime <= startTime)
            {
                ErrorMessage = "Sluttidspunktet skal være efter starttidspunktet.";
                return null;
            }

            if (!IsValidBookingRule(room, startTime, endTime, bookingPartId))
            {
                return null;
            }

            bool studentLimitOk = await StudentCanBookAsync(userId, startTime);

            if (!studentLimitOk)
            {
                ErrorMessage = "En studerende må ikke booke for mange lokaler på samme dag.";
                return null;
            }

            bool available = await CheckAvailabilityAsync(
                roomId,
                startTime,
                endTime,
                bookingPartId);

            if (!available)
            {
                ErrorMessage = "Lokalet er allerede booket i dette tidsrum.";
                return null;
            }

            var booking = new Booking
            {
                UserId = userId,
                RoomId = roomId,
                StartTime = startTime,
                EndTime = endTime,
                BookingDate = startTime.Date,
                BookingPartId = bookingPartId,
                Status = true
            };

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveAsync();

            return booking;
        }

        public async Task UpdateBookingAsync(Booking updatedBooking)
        {
            var booking = await _bookingRepository.FindByIdAsync(updatedBooking.BookingId);

            if (booking != null)
            {
                booking.UserId = updatedBooking.UserId;
                booking.RoomId = updatedBooking.RoomId;
                booking.StartTime = updatedBooking.StartTime;
                booking.EndTime = updatedBooking.EndTime;
                booking.BookingDate = updatedBooking.StartTime.Date;
                booking.BookingPartId = updatedBooking.BookingPartId;
                booking.Status = updatedBooking.Status;

                await _bookingRepository.SaveAsync();
            }
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            ErrorMessage = "";

            var booking = await _bookingRepository.FindByIdAsync(bookingId);

            if (booking == null)
            {
                ErrorMessage = "Bookingen findes ikke.";
                return;
            }

            if (booking.StartTime.Date < DateTime.Now.Date.AddDays(3))
            {
                ErrorMessage = "Bookingen kan kun annulleres med mindst 3 dages varsel.";
                return;
            }

            booking.Status = false;
            await _bookingRepository.SaveAsync();
        }

        public async Task<bool> CheckAvailabilityAsync(
            int roomId,
            DateTime startTime,
            DateTime endTime,
            int? bookingPartId)
        {
            var bookings = await _bookingRepository.FindByRoomAsync(roomId);

            foreach (var booking in bookings)
            {
                if (!booking.Status)
                {
                    continue;
                }

                bool sameTime =
                    startTime < booking.EndTime &&
                    endTime > booking.StartTime;

                if (!sameTime)
                {
                    continue;
                }

                bool samePart =
                    booking.BookingPartId == bookingPartId ||
                    bookingPartId == null ||
                    booking.BookingPartId == null;

                if (samePart)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidBookingRule(
            Room room,
            DateTime startTime,
            DateTime endTime,
            int? bookingPartId)
        {
            var duration = endTime - startTime;
            var roomType = room.RoomType?.TypeName ?? "";

            if (roomType == "Mødelokale")
            {
                if (duration.TotalHours != 2)
                {
                    ErrorMessage = "Mødelokaler skal bookes i præcis 2 timer.";
                    return false;
                }

                return true;
            }

            if (roomType == "Klasselokale")
            {
                if (bookingPartId == null || duration.TotalHours != 2)
                {
                    ErrorMessage = "Klasselokaler skal deles mellem grupper og bookes i 2 timer.";
                    return false;
                }

                return true;
            }

            if (roomType == "Auditorium")
            {
                if (duration.TotalHours != 1)
                {
                    ErrorMessage = "Auditorium skal bookes 1 time ad gangen.";
                    return false;
                }

                if (startTime.Date < DateTime.Now.Date.AddDays(2))
                {
                    ErrorMessage = "Auditorium skal bookes mindst 2 dage før.";
                    return false;
                }

                if (bookingPartId == null)
                {
                    ErrorMessage = "Auditorium skal bookes med en bookingdel.";
                    return false;
                }

                return true;
            }

            if (duration.TotalHours > 2)
            {
                ErrorMessage = "Lokalet kan højst bookes i 2 timer.";
                return false;
            }

            return true;
        }

        private async Task<bool> StudentCanBookAsync(int userId, DateTime startTime)
        {
            var userBookings = await _bookingRepository.FindByUserAsync(userId);

            int bookingsSameDay = userBookings.Count(b =>
                b.Status &&
                b.BookingDate.Date == startTime.Date);

            return bookingsSameDay < 2;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<List<BookingPart>> GetAllBookingPartsAsync()
        {
            return await _bookingRepository.GetAllBookingPartsAsync();
        }
    }
}