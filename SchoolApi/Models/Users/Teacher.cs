using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Teacher
{
    public int TeacherId{init;get;}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Level TeachLevel { set; get; }
    public Course? Course { set; get; }
    // [MaxLength(50)]
    // public string CourseName { set; get; } = "";
    // public int CourseId { set; get; }
}