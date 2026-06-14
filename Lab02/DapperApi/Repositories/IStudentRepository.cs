using DapperApi.Models;

namespace DapperApi.Repositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    IEnumerable<Student> SearchByName(string name);
    IEnumerable<StudentWithCourse> getAllWithCourse(); 
    Student? GetById(int id);
    void Create(Student student);
    void Update(Student student);
    void Delete(int id);
}