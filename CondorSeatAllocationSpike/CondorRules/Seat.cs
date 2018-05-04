namespace CondorRules
{
    internal class Seat
    {
        readonly SeatRow _row;
        readonly int _sectionNumber;
        string _customer;

        public int Number { get; }
        public bool IsEndSeat { get; set; }

        public Seat(int number, SeatRow row, int sectionNumber)
        {
            _row = row;
            _sectionNumber = sectionNumber;
            Number = number;
            _row.AddSeat(this, sectionNumber);
        }

        public void Book(string customer)
        {
            _customer = customer;
        }

        public SeatOffer GetSeatOffer()
        {
            return new SeatOffer(row: _row.Number, section: _sectionNumber, seat: Number, customer: _customer);
        }
    }
}