using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class BuyersModel
{
    [Key] public int IDBuyers { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? BuyersAddress { get; set; }
}
