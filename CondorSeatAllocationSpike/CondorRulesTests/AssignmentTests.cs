using System;
using CondorRules;
using NUnit.Framework;
using Shouldly;

namespace CondorRulesTests
{
    
    public class AssignmentTests
    {
        protected SeatingPlan SeatingPlan;

        [SetUp]
        public void Because_of_having_ship_with_seats()
        {
            SeatingPlan = new SeatingPlan();
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 1, seatNumber: 1);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 1, seatNumber: 2);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 1, seatNumber: 3);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 1, seatNumber: 4);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 1, seatNumber: 5);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 2, seatNumber: 6);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 2, seatNumber: 7);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 3, seatNumber: 8);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 3, seatNumber: 9);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 3, seatNumber: 10);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 3, seatNumber: 11);
            SeatingPlan.AddSeat(rowNumber: 1, sectionNumber: 3, seatNumber: 12);

            SeatingPlan.AddSeat(rowNumber: 2, sectionNumber: 1, seatNumber: 13);
            SeatingPlan.AddSeat(rowNumber: 2, sectionNumber: 1, seatNumber: 14);
            SeatingPlan.AddSeat(rowNumber: 2, sectionNumber: 1, seatNumber: 15);
            SeatingPlan.AddSeat(rowNumber: 2, sectionNumber: 1, seatNumber: 16);


            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 1, seatNumber: 17);
            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 1, seatNumber: 18);
            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 1, seatNumber: 19);
            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 1, seatNumber: 20);

            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 2, seatNumber: 21);
            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 2, seatNumber: 22);
            SeatingPlan.AddSeat(rowNumber: 3, sectionNumber: 2, seatNumber: 23);
        }

        [TestFixture]
        public class When_booking_as_a_passenger_quantity_of_1 : AssignmentTests
        {
            [SetUp]
            public void Because_section_has_section_with_only_one_seat_in_it()
            {
                BookSeats(from: 1, to: 1, customer: "customer 1");
                BookSeats(from: 3, to: 23, customer: "customer 1");
            }

            public void It_should_offer_me_the_only_available_seat()
            {
                ShouldBeSeat(partySize: 1, expectedSeatNumber: 12, expectedRow: 1, expectedSection: 3);
            }
        }

        // can't book a booked seat!

        // no seats found togeter, book in smaller parties!

        protected void ShouldBeSeat(int partySize, int expectedSeatNumber, int expectedRow, int expectedSection)
        {
            var seatOffered = SeatingPlan.GetSeatOfferedFor(partySize);
            seatOffered.Seat.ShouldBe(expectedSeatNumber);
            seatOffered.Row.ShouldBe(expectedRow);
            seatOffered.Section.ShouldBe(expectedSection);
            seatOffered.Customer.ShouldBe("customer 1");
        }

        protected void BookSeats(int from, int to, string customer)
        {
            for (var seat = from; seat <= to; seat++)
            {
                SeatingPlan.BookSeat(seat);
            }
        }
    }
}
