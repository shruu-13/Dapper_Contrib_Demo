using Dapper.Contrib.Extensions;

namespace Dapper_Contrib.Models
{

	[Table("School") ]
	public class School
	{
		[ExplicitKey]
		public int School_Id { get; set; }

		public string Scl_name { get; set; }

	}
}
