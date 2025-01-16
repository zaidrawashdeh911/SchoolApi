namespace SchoolApi.Models.Users;
public abstract class Human
{
    public string Name { set; get; } = "";
    protected int Age{set;get;}
    protected string Gender{set;get;}= "";
    
    protected string Phone{set;get;}= "";
    protected string Email{set;get;}= "";
    protected string Address{set;get;}= "";


    public virtual void Print()
    {
        Console.WriteLine("I am a human");
    }
    
}

