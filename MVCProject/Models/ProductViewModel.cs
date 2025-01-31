using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVCProject.Models
{
	public class ProductViewModel
	{
		public required int Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public required decimal Price { get; set; }
		public required DateTime DateTime { get; set; }
	}
}
