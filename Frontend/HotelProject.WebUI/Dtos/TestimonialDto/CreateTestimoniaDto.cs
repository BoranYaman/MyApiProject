﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
       
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }


    }
}
