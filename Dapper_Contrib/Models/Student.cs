using Dapper.Contrib.Extensions;

namespace Dapper_Contrib.Models
{
	[Table("Student")]
	public class Student
	{
		[Key]
		public int Roll_no { get; set; } 

		public string Fname { get; set; }

		public string Lname { get; set; }
	}
}
