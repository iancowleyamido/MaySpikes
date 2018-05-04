using System.Collections.Generic;
using System.Linq;

namespace CondorRules
{
    internal class SeatSection
    {
        readonly Dictionary<int, Seat> _seats;
        int endSeatIndex = 0;

        public int Number { get; }

        public SeatSection(int number)
        {
            Number = number;
            _seats = new Dictionary<int, Seat>();
        }

        public void AddSeat(Seat seat)
        {
            _seats[seat.Number] = seat;

            if (IsNowTheEndSeat(seat.Number))
            {
                _seats[endSeatIndex].IsEndSeat = false;
                seat.IsEndSeat = true;
            }
        }

        bool IsNowTheEndSeat(int seatNumber)
        {
            return seatNumber > endSeatIndex;
        }

        public IEnumerable<Seat> GetSingleSeats()
        {
            if (NoSeats())
            {
                return new Seat[0];
            }
          
            // binary chop!  figure out  middle number is the same amount as the number of elements from the start!
            if (_seats.Count + 1 == _seats.Max(x => x.Key))
            {

            }
        }

        bool NoSeats()
        {
            return !_seats.Any();
        }
    }
}