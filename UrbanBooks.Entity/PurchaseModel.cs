using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Entity
{
    public class PurchaseModel
    {
        [Required(ErrorMessage="Name is Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Address is Required.")]
        public string Address { get; set; }
        [Required(ErrorMessage="Delivery Address is Required.")]
        public string DeliveryAddress { get; set; }
    }
}
