using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
	[Table("Customer")]
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string CustomerName { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string CustomerEmail { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string CustomerPassword { set; get; }
		[Column(TypeName = "varchar(100)")]
		public string CustomerAddress { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string CustomerPhoneNo { set; get; }
		public ICollection<CustomerOrderDetails> CustomerOrderDetails { set; get; }
	}
}
