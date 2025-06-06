using BookingSystemAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingSystemAPI : ControllerBase
{
    private static List<BookingModel> bookings = new List<BookingModel>();

    [HttpPost] //新增定位
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

        if(!ModelState.IsValid)  //防止傳送空白資料
        {
            return BadRequest(ModelState);
        }

        bookings.Add(newBooking);
        return Ok(newBooking);
    }

    [HttpGet] //取得訂位
    public IActionResult Get()
    {
        return Ok(bookings);
    }

    [HttpGet("{id}")] //取的指定訂位
    public IActionResult Get(int id)
    {
        var thisbookings = bookings.FirstOrDefault(n => n.Id == id);
        if (thisbookings == null)
        {
            return NotFound("查無此訂位");
        }
        return Ok(thisbookings);
    }

    [HttpDelete("{id}")] //刪除訂位
    public IActionResult Delete(int id)
    {
        var thisdebooking = bookings.FirstOrDefault(n => n.Id == id);
        if (thisdebooking == null)
        {
            return NotFound("查無此訂位");
        }
        bookings.Remove(thisdebooking);
        return Ok(thisdebooking);
    }

    [HttpPut("{id}")] //修改訂位(需都填)
    public IActionResult Put(int id, [FromBody]  BookingModel model)
    {
        var booking = bookings.FirstOrDefault(n => n.Id==id);
        if(booking == null)
        {
            return NotFound("查無此訂位");
        }

        booking.Name = model.Name;
        booking.Phone = model.Phone;
        booking.Email = model.Email;
        booking.SpecialNote = model.SpecialNote;
        booking.NumberOfPeople = model.NumberOfPeople;
        booking.BookingDateTime = model.BookingDateTime;

        if (!ModelState.IsValid)  //防止傳送空白資料
        {
            return BadRequest(ModelState);
        }

        return Ok(booking);
    }

}
