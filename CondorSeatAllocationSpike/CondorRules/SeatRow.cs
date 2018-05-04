using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CondorRules
{
    internal class SeatRow
    {
        readonly Dictionary<int, SeatSection> _sections;

        public int Number { get; }

        public SeatRow(int number)
        {
            Number = number;
            _sections = new Dictionary<int, SeatSection>();
        }
        
        public IEnumerable<Seat> GetSingleSeats()
        {
            return _sections.Values.SelectMany(x => x.GetSingleSeats());
        }

        public void AddSeat(Seat seat, int sectionNumber)
        {
            if (!_sections.TryGetValue(sectionNumber, out var section))
            {
                section = new SeatSection(sectionNumber);
                _sections[sectionNumber] = section;
            }

            section.AddSeat(seat);
        }
    }
}