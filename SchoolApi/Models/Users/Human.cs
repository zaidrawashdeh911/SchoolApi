using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models.Users;
public class Human
{
    public int HumanId { get; init; }
    
    [MaxLength(50)] 
    public string Name { set; get; } = "";
    
    public DateOnly Birthday { get; init; } 
    
    [MaxLength(10)] 
    public string Gender{init;get;}= "";
    [MaxLength(15)] 
    public string Phone{set;get;}= "";
    [MaxLength(25)] 
    public string Email{set;get;}= "";
    [MaxLength(200)]
    public string Address{set;get;}= "";


    // public virtual void Print()
    // {
    //     Console.WriteLine("I am a human");
    // }
    
}

