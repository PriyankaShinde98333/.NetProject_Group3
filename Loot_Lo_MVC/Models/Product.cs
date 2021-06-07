using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_MVC.Models
{
    public class Product
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string ProductName { set; get; }
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { set; get; }
		[Required]
		public int Quantity { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string ImagePath { set; get; }
		//[Required]
		//[ForeignKey("Category")]
		public int CategoryRefId { get; set; }
		[ForeignKey("CategoryRefId")]

		//public string CategoryName { get; set; }
		public Category Category { get; set; }
		//[Required]
		//[ForeignKey("Admin")]
		//public int AdminRefId { get; set; }
		//[ForeignKey("AdminRefId")]
		//public Admin Admin { get; set; }
	}
}
