using System;
using DapperApi.Model;
namespace DapperApi.Repositories;

public interface IStudentRepository {
    IEnumerable<Student> getAll();
    Student ? getByID(Int id);
    void Create(Student student);
    void Updaye(Sttudent student);
    void Delete(int ID);
    
}