using System;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using DapperApi.Model'

public  StudentRepository : IStudentRepository {
    private readonly string _ConnStr;
    public StudentRepository(IConfiguration config) {
        _ConnStr = config.getConnectionString("DefalutConnection");
    }

    /*get ALL*/
    private IDbConnection NewConnection() => new SqlConnection(_ConnStr);
    public IEnumerable<Student> getAll() {
        using var db = new Connection();
        return db.Query<Student>("SELECT * FROM Students");
    }

    /* get by ID*/
    public Student? getByID(int ID) {
        using var db = new Connection();
        db.QuerySingleOrDefault<Student>("SELECT * FROM Students Where Id = @Id",new {Id = ID});
    }
    /* Create*/
    public void Create(Student student) {
        using var db = new Connection();
        db.Execute( 
            "ISERTINTO Students (name,age) VALUES (@name,@age)",student
        );
    }

    /* UPDATE */
    public void Update(Student student) {
        using var db = new Connection();
        db.Execute(
            "UPDATE Students SET name = @name;age = @age WHERE ID = @ID",student
        );
    }

    /* DELETE */
    public  void Delete(int id) {
        using var db = new Connection();
        db.Execute(
            "DELETE FROM Sudents WHERE Id = @Id",new {Id = id}
        ); 
    }


}
