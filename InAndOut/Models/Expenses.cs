using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
	public class Expense
	{
		[Key]
		public int Id { get; set; }
		[DisplayName("Expense Name")]
		[Required]
		public string ExpenseName { get; set; }
		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Cost must be greater than 0!")]
		public int Cost { get; set; }
	}
}
