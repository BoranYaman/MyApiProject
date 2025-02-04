using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID {  get; set; }
        [Required(ErrorMessage = "Servis ikon Linki Giriniz")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En fazla 100 Karakter Olabilir")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Hizmet Açıklama Giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklama En fazla 500 Karakter Olabilir")]
        public string? Description { get; set; }
    }
}
