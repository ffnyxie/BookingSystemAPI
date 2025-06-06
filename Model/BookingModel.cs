using System.ComponentModel.DataAnnotations;
using System;

namespace BookingSystemAPI.Model
{
    public class BookingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="姓名不得為空")]
        public string Name { get; set; }

        [Required(ErrorMessage ="電話不得為空")]
        [Phone(ErrorMessage ="電話格式錯誤")]
        public string Phone { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage ="人數需為1~10之間")]
        [Range(1,10)]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "時間不得為空")]
        public DateTime BookingDateTime { get; set; }
        public string SpecialNote { get; set; }
    }
}
