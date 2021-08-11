using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.Models
{
    public class PaintingView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}
