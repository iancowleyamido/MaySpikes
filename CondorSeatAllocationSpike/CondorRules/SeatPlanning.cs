using System;
using System.Collections.Generic;

namespace CondorRules
{
    public class SeatingPlan
    {
        internal Dictionary<int, Seat> Seats { get; }
        internal Dictionary<int, SeatRow> Rows { get; }
        readonly SeatSearch _seatSearch;

        public SeatingPlan()
        {
            Seats = new Dictionary<int, Seat>();
            Rows = new Dictionary<int, SeatRow>();
            _seatSearch = new SeatSearch(this);
        }

        public void AddSeat(int rowNumber, int sectionNumber, int seatNumber)
        {
            if (!Rows.TryGetValue(rowNumber, out var row))
            {
                row = new SeatRow(rowNumber);
                Rows[rowNumber] = row;
            }

            var seat = new Seat(seatNumber, row, sectionNumber);
            Seats[seatNumber] = seat;
        }

        public SeatOffer GetSeatOfferedFor(int partySize)
        {
            
        }

        public void BookSeat(int seatNumber, string customer)
        {
            if (!Seats.TryGetValue(seatNumber, out var seat))
            {
                throw new ArgumentException($"SeatNumber {seatNumber} does not exist");
            }

            seat.Book(customer);
        }
    }
}
