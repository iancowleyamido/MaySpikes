namespace CondorRules
{
    public class SeatOffer
    {
        public int Row { get; }
        public int Section { get; }
        public int Seat { get; }
        public string Customer { get; }

        public SeatOffer(int row, int section, int seat, string customer)
        {
            Row = row;
            Section = section;
            Seat = seat;
            Customer = customer;
        }
    }
}