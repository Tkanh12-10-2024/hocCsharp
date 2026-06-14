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
        using var db = NewConnection();

        return db.Query<Student>(
            "SELECT * FROM Students");
    }

    public Student? GetById(int id)
    {
        using var db = NewConnection();

        return db.QuerySingleOrDefault<Student>(
            "SELECT * FROM Students WHERE Id=@Id",
            new { Id = id });
    }

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
            @"UPDATE Students
              SET Name=@Name,
                  Age=@Age,
                  Email=@Email
              WHERE Id=@Id",
            student);
    }

    public void Delete(int id)
    {
        using var db = NewConnection();

        db.Execute(
            "DELETE FROM Students WHERE Id=@Id",
            new { Id = id });
    }

    public IEnumerable<Student> SearchByName(string name)
    {
        using var db = NewConnection();

        return db.Query<Student>(
            "SELECT * FROM Students WHERE Name LIKE @Name",
            new { Name = "%" + name + "%" });
    }

    public IEnumerable<StudentWithCourse> getAllWithCourse()
    {
        var sql = @"
        SELECT
            s.Id,
            s.Name,
            c.Id,
            c.CourseName
        FROM Students s
        JOIN StudentCourses sc
            ON s.Id = sc.StudentId
        JOIN Courses c
            ON sc.CourseId = c.Id
        ORDER BY s.Id";

        using var db = NewConnection();

        var dic = new Dictionary<int, StudentWithCourse>();

        db.Query<StudentWithCourse,
                 Course,
                 StudentWithCourse>(
            sql,
            (student, course) =>
            {
                if (!dic.TryGetValue(student.Id, out var existing))
                {
                    existing = student;
                    dic.Add(student.Id, existing);
                }

                existing.Couse.Add(course);

                return existing;
            },
            splitOn: "Id");

        return dic.Values;
    }
}