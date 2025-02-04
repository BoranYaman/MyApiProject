
using System.ComponentModel.DataAnnotations;



namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class CreateRoomDto
    {
        [Required(ErrorMessage = "Oda Numarasını giriniz")]
        public string? RoomNumber { get; set; }
        [Required(ErrorMessage = "Fiyat Bilgisi Giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Başlık Bilgisi Giriniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Yatak Odası Bilgisi Giriniz")]
        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Banyo Bilgisi Giriniz")]
        public string? BathCount { get; set; }
        [Required(ErrorMessage = "Wifi Bilgisi Giriniz")]

        public string? Wifi { get; set; }
        [Required(ErrorMessage = "Açıklama Bilgisi Giriniz")]

        public string? Description { get; set; }


    }
}
