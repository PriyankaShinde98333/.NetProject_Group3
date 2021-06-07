using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
	[Table("Admin")]
	public class Admin
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdminId { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string AdminName { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string AdminEmail { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string AdminPassword { set; get; }
		
	}
}