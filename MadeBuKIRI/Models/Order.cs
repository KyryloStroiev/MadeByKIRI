using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class Order
{
	[BindNever]
	[Key] public int Id { get; set; }
	[Display(Name = "Enter Name")]
	[StringLength(50, MinimumLength = 2)]
	[Required(ErrorMessage = " Довжина не менше 2 символів ")]
	public string Name { get; set; }
	[Display(Name = "Enter SurName")]
	[StringLength(50, MinimumLength = 2)]
	[Required(ErrorMessage = " Довжина не менше 2 символів ")]
	public string SurName { get; set; }
	[Display(Name = "Enter Adress")]
	[StringLength(int.MaxValue, MinimumLength = 15)]
	[Required(ErrorMessage = " Довжина не менше 15 символів ")]
	public string Adress { get; set; }
	[Display(Name = "Enter phone number")]
	[DataType(DataType.PhoneNumber)]
	[StringLength(85, MinimumLength = 8)]
	[Required(ErrorMessage = " Довжина не менше 8 символів ")]
	public string Phone { get; set; }
	[Display(Name = "Enter Email")]
	[DataType(DataType.EmailAddress)]
	[StringLength(100, MinimumLength = 5)]
	[Required(ErrorMessage = " Довжина не менше 5 символів ")]
	public string Email { get; set; }
	public DateTime OrderTime { get; set; }

	public List<OrderDetail> OrderDetail { get; set; }
}
