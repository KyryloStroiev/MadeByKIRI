using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class Order
{
	[BindNever]
	[Key] public int Id { get; set; }
	[Display(Name = "Enter Name")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }
	[Display(Name = "Enter SurName")]
	[StringLength(50, MinimumLength = 2)]
	public string SurName { get; set; }
	[Display(Name = "Enter Adress")]
	[StringLength(int.MaxValue, MinimumLength = 15)]
	public string Adress { get; set; }
	[Display(Name = "Enter phone number")]
	[DataType(DataType.PhoneNumber)]
	[StringLength(50, MinimumLength = 5)]
	public string Phone { get; set; }
	[Display(Name = "Enter Email")]
	[DataType(DataType.EmailAddress)]
	[StringLength(100, MinimumLength = 5)]
	public string Email { get; set; }
	public DateTime OrderTime { get; set; }

	public List<OrderDetail> OrderDetail { get; set; }
}
