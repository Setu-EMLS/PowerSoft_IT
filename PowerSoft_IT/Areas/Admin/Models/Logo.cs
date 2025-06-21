using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerSoft_IT.Areas.Admin.Models
{
    public class Logo
    {
        public int Id { get; set; }
        [ValidateNever]
        public string logoPath { get; set; }
        [ValidateNever]
        public string IconPath { get; set; }
        [NotMapped]
        public IFormFile IconPicture { get; set; }
        [NotMapped]
        public IFormFile LogoPicture { get; set; }
    }
}
