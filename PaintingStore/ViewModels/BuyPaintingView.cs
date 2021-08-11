using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.ViewModels
{
    public class BuyPaintingView
    {
        [Required(ErrorMessage ="Without your consent buying process can't be done")]
        [Display(Name = "I know the Terms & Conditions")]
        public bool Term { get; set; }
    }
}
