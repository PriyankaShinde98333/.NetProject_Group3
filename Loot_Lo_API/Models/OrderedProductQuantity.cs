using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
    [Table("OrderedProductQuantity")]
    public class OrderedProductQuantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderedProductQuantityId { set; get; }
        [Required]
        public int ProductRefId { set; get; }
        [ForeignKey("ProductRefId")]
        public Product Product { set; get; }
        public int Quantity { set; get; }
        [Required]
        public int OrderRefId { get; set; }
        [ForeignKey("OrderRefId")]
        public CustomerOrderDetails CustomerOrderDetails { get; set; }


    }
}
