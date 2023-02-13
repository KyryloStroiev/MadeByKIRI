namespace MadeByKIRI.Models;

public class Login
{
    public int Id { get; set; } 
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string Role { get; set; }
}
