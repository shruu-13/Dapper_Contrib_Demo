using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Dapper_Contrib.Models
{
	[Table("Teacher") ]
	public class Teacher
	{
		[Key]
		public int Teacher_id { get; set; }
		 
		public string F_name { get; set; }

		public string L_name { get; set; }

		public string Subject { get; set; }

	}
}
