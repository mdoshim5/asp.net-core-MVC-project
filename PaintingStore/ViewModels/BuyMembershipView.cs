using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.ViewModels
{
    public class BuyMembershipView
    {
        [Required]
        public string Membership { get; set; }
    }
}
