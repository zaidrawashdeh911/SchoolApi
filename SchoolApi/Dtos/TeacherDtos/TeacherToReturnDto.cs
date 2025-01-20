using System.Text.Json.Serialization;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Dtos.TeacherDtos;

public class TeacherToReturnDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Level TeachLevel { get; set; }
    public Course? Course { get; set; }
}