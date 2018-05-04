using System.Linq;

namespace CondorRules
{
    public class SeatSearch
    {
        readonly SeatingPlan _seatingPlan;
        readonly ISeatAvailabilityRule[] _seatAvailabilityRules;

        public SeatSearch(SeatingPlan seatingPlan)
        {
            _seatingPlan = seatingPlan;
            _seatAvailabilityRules = new[] {new SinglePartyAvailabilityRule()};
        }

        public SeatOffer FindAvailableSeat(int sizeOfParty)
        {
            foreach (var row in _seatingPlan.Rows)
            {
                foreach (var seatAvailabilityRule in _seatAvailabilityRules)
                {
                    var seat = seatAvailabilityRule.GetAvailableSeat(row);
                    if (seat != null)
                    {
                        return seat.GetSeatOffer();
                    }
                }
            }

            return null;
        }
    }

    public class SinglePartyAvailabilityRule : ISeatAvailabilityRule
    {
        public Seat GetAvailableSeat(SeatRow row)
        {
            foreach (var singleSeat in row.GetSingleSeats())
            {
                return row.
            }
        }
    }

    internal interface ISeatAvailabilityRule
    {
        Seat GetAvailableSeat(SeatRow row);
    }
}