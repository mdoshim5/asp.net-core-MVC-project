using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.ViewModels
{
    public class CreateViewForPaintings
    {
        [Required(ErrorMessage ="Enter the Painting Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the Painting's Artist-Name")]
        public string Artist { get; set; }
        [Required(ErrorMessage ="Upload an Image")]
        public IFormFile Photo { get; set; }
    }
}
