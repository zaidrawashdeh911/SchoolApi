using System.Text.Json.Serialization;
using SchoolApi.Data;

namespace SchoolApi.Dtos.StudentDtos;

public class StudentToReturnDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StudentType StudentType{get;set;}
    public int Level{get;set;}
}