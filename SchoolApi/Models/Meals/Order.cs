using System.ComponentModel.DataAnnotations;
using SchoolApi.Data;

namespace SchoolApi.Models.Meals;

public class Order
{
    public int OrderId { get; set; }
    public int StudentId { get; set; }
    [MaxLength(200)] 
    public string BreakfastOrder { set; get; } = "";
    [MaxLength(200)] 
    public string LunchOrder { set; get; } = "";
    

    // public void CookingMenu(int mealsMenu)
    // {
    //     IMenu menu = new Menu();
    //     if (mealsMenu==1)
    //     {
    //         menu.BreakfastMenu();
    //     }else if (mealsMenu == 2)
    //     {
    //         menu.LunchMenu();
    //     }
    //     else
    //     {
    //         throw new Exception("Not an option");
    //     }
    // }
    // private enum Breakfast
    // {
    //     ScrambledOrOmelet =1, 
    //     Hashbrowns,
    //     Pancakes,
    //     Croissants,
    //     CerealsOrOatmeal
    // }
    //
    // private enum Lunch
    // {
    //     ChickenCurry=1,
    //     ChickenFricassee,
    //     BakedFishNibbles,
    //     BeefBurger,
    //     TunaAndAvocadoSalad,
    //     BeefTacos
    // }
}