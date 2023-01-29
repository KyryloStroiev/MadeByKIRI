using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class Buyers : BuyersModel
{
    //public List<Goods> Goods { get; set; }
    public List<Order> Order { get; set; }
    public Buyers() { }
    public Buyers (BuyersModel buyersModel )
    {
        IDBuyers= buyersModel.IDBuyers;
        FullName= buyersModel.FullName;
        Email= buyersModel.Email;
        Phone = buyersModel.Phone;
        Password= buyersModel.Password;
        BuyersAddress = buyersModel.BuyersAddress;
    }
   
}
