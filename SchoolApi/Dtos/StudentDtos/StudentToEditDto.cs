using SchoolApi.Data;

namespace SchoolApi.Dtos.StudentDtos;

public class StudentToEditDto
{
    public int StudentId{get;init;}
    public StudentType StudentType{get;set;}
    public int Level{get;set;}
}