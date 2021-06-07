using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_MVC.Models
{
    public class Category
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string CategoryName { set; get; }
		public ICollection<Product> Products { set; get; }
	}
}
