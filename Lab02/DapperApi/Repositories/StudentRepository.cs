using DapperApi;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using DapperApi.Models;



namespace DapperApi.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string _connStr;

    public StudentRepository(IConfiguration config)
    {
        _connStr = config.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection NewConnection()
        => new SqlConnection(_connStr);

    public IEnumerable<Student> GetAll()
    {
        Console.WriteLine("Connected!");
        using var db = NewConnection();
        return db.Query<Student>("SELECT * FROM Students");
    }

    public Student? GetById(int id)
    {
        using var db = NewConnection();

        return db.QuerySingleOrDefault<Student>(
            "SELECT * FROM Students WHERE Id=@Id",
            new { Id = id });
    }


    /* Create new student*/
    public void Create(Student student)
    {
        using var db = NewConnection();
        db.Execute(
            "INSERT INTO Students(Name,Age,Email) VALUES(@Name,@Age,@Email)",
            student);
    }

    public void Update(Student student)
    {
        using var db = NewConnection();

        db.Execute(
            "UPDATE Students SET Name=@Name, Age=@Age WHERE Id=@Id,Email=@Email WHERE Id = @Id",
            student);
    }

    public void Delete(int id)
    {
        using var db = NewConnection();

        db.Execute(
            "DELETE FROM Students WHERE Id=@Id",
            new { Id = id });
    }

    // search by name
    public IEnumerable<Student> SearchByName(string name)
    {
        using var db = NewConnection();
        return db.Query<Student>(
            "SELECT* FROM Students WHERE Name like @Name", new { Name = "%" + name + "%"}
        );
    }
    
}