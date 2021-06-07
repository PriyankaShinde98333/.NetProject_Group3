﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Loot_Lo_API.Models
{
	[Table("Product")]
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
		public Category Category { get; set; }
		public string CategoryName { get; set; }
		//[Required]
		//[ForeignKey("Admin")]
		//public int AdminRefId { get; set; }
		//[ForeignKey("AdminRefId")]
		//public Admin Admin { get; set; }
	}
}