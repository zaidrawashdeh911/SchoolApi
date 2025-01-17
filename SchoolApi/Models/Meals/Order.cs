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
}