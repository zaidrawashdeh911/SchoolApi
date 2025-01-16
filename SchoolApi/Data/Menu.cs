namespace SchoolApi.Data;
public class Menu: IMenu
{
    public void BreakfastMenu()
    {
        Console.WriteLine("\nCafeteria Breakfast Menu: ");
        Console.WriteLine("\nScrambled or Omelet Eggs");
        Console.WriteLine("Hashbrowns");
        Console.WriteLine("Pancakes");
        Console.WriteLine("Croissants");
        Console.WriteLine("Cereals or Oatmeal");
    }
    
    public void LunchMenu()
    {
        Console.WriteLine("\nCafeteria Lunch Menu: ");
        Console.WriteLine("\nChicken Curry");
        Console.WriteLine("Chicken Fricassee");
        Console.WriteLine("Baked Fish Nibbles");
        Console.WriteLine("Beef Burger");
        Console.WriteLine("Tuna and Avocado Salad");
        Console.WriteLine("Beef Tacos");
    }
}