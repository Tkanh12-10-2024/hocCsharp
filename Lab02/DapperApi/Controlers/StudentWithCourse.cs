using DapperApi.Models;

public class StudentWithCourse
{
    public int Id {get;set;}
    public string? name = "";
    public List<Course> Couse {get;set;} = new();
    
}