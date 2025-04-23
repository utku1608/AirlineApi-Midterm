using AirlineApi.Models;
using AirlineApi.Models.DTOs;

namespace AirlineApi.Services

{
    public class FlightService
    {
        private readonly List<Flight> _flights = new();
        
        public List<Flight> QueryFlights(QueryFlightRequest request)
{
    var flights = _flights.Where(f =>
        f.DateFrom.Date >= request.DateFrom.Date &&
        f.DateTo.Date <= request.DateTo.Date &&
        string.Equals(f.AirportFrom, request.AirportFrom, StringComparison.OrdinalIgnoreCase) &&
        string.Equals(f.AirportTo, request.AirportTo, StringComparison.OrdinalIgnoreCase) &&
        f.AvailableSeats >= request.NumberOfPeople
    );

    return flights
        .Skip((request.Page - 1) * request.PageSize)
        .Take(request.PageSize)
        .ToList();
}
public (bool success, string message, string? ticketNumber) BuyTicket(BuyTicketRequest request)
{
    var flight = _flights.FirstOrDefault(f => f.Id == request.FlightId && f.DateFrom.Date == request.Date.Date);
    
    if (flight == null)
    {
        return (false, "Flight not found", null);
    }

    if (flight.AvailableSeats <= 0)
    {
        return (false, "sold out", null);
    }

    flight.AvailableSeats--;

    var ticketNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

    return (true, "ticket purchased", ticketNumber);
}
private readonly List<Passenger> _passengers = new();

public (bool success, string message, string? seatNumber) CheckIn(CheckInRequest request)
{
    var existing = _passengers.FirstOrDefault(p =>
        p.FlightId == request.FlightId &&
        p.Date.Date == request.Date.Date &&
        p.Name.Equals(request.PassengerName, StringComparison.OrdinalIgnoreCase));

    if (existing != null)
    {
        return (true, "already checked in", existing.SeatNumber);
    }

    var flight = _flights.FirstOrDefault(f =>
        f.Id == request.FlightId && f.DateFrom.Date == request.Date.Date);

    if (flight == null)
    {
        return (false, "Flight not found", null);
    }

    // Seat numarası basit sistemle: P1, P2...
    var seatNumber = "P" + (_passengers.Count + 1);

    var passenger = new Passenger
    {
        FlightId = request.FlightId,
        Date = request.Date,
        Name = request.PassengerName,
        SeatNumber = seatNumber
    };

    _passengers.Add(passenger);

    return (true, "checked in", seatNumber);
}
public List<Passenger> GetPassengers(QueryPassengerListRequest request)
{
    return _passengers
        .Where(p => p.FlightId == request.FlightId && p.Date.Date == request.Date.Date)
        .Skip((request.Page - 1) * request.PageSize)
        .Take(request.PageSize)
        .ToList();
}




        public Flight AddFlight(AddFlightRequest request)
        {
            var flight = new Flight
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                AirportFrom = request.AirportFrom,
                AirportTo = request.AirportTo,
                Duration = request.Duration,
                Capacity = request.Capacity,
                AvailableSeats = request.Capacity
            };

            _flights.Add(flight);
            return flight;
        }

        public List<Flight> GetAllFlights() => _flights;
    }
}

