using BookingSystemAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingSystemAPI : ControllerBase
{
    private static List<BookingModel> bookings = new List<BookingModel>();

    [HttpPost] //�s�W�w��
    public IActionResult Post([FromBody] BookingModel model)
    {
        var newBooking = new BookingModel
        {
            Id = bookings.Count + 1,
            Name = model.Name,
            Phone = model.Phone,
            Email = model.Email,
            SpecialNote = model.SpecialNote,
            NumberOfPeople = model.NumberOfPeople,
            BookingDateTime = model.BookingDateTime
        };

        if(!ModelState.IsValid)  //����ǰe�ťո��
        {
            return BadRequest(ModelState);
        }

        bookings.Add(newBooking);
        return Ok(newBooking);
    }

    [HttpGet] //���o�q��
    public IActionResult Get()
    {
        return Ok(bookings);
    }

    [HttpGet("{id}")] //�������w�q��
    public IActionResult Get(int id)
    {
        var thisbookings = bookings.FirstOrDefault(n => n.Id == id);
        if (thisbookings == null)
        {
            return NotFound("�d�L���q��");
        }
        return Ok(thisbookings);
    }

    [HttpDelete("{id}")] //�R���q��
    public IActionResult Delete(int id)
    {
        var thisdebooking = bookings.FirstOrDefault(n => n.Id == id);
        if (thisdebooking == null)
        {
            return NotFound("�d�L���q��");
        }
        bookings.Remove(thisdebooking);
        return Ok(thisdebooking);
    }

    [HttpPut("{id}")] //�ק�q��(�ݳ���)
    public IActionResult Put(int id, [FromBody]  BookingModel model)
    {
        var booking = bookings.FirstOrDefault(n => n.Id==id);
        if(booking == null)
        {
            return NotFound("�d�L���q��");
        }

        booking.Name = model.Name;
        booking.Phone = model.Phone;
        booking.Email = model.Email;
        booking.SpecialNote = model.SpecialNote;
        booking.NumberOfPeople = model.NumberOfPeople;
        booking.BookingDateTime = model.BookingDateTime;

        if (!ModelState.IsValid)  //����ǰe�ťո��
        {
            return BadRequest(ModelState);
        }

        return Ok(booking);
    }

}
