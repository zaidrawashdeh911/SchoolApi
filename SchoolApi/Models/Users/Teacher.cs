using System.ComponentModel.DataAnnotations;
using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Teacher
{
    public int TeacherId{init;get;}
    public Level TeachLevel { set; get; }
    public Course? Course{set; get;}
}