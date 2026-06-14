namespace DapperApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using DapperApi.Models;
using DapperApi.Repositories;

[ApiController]

[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repo;

    public StudentsController(IStudentRepository repo)
    {
        _repo = repo;
    }

    // GET: api/students
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repo.GetAll());
    }

    // GET: api/students/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _repo.GetById(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public IActionResult Create(Student student)
    {
        _repo.Create(student);
        return Ok("Them sinh vien thanh cong");
    }

    // PUT: api/students
    [HttpPut]
    public IActionResult Update(Student student)
    {
        _repo.Update(student);
        return Ok("Cap nhat thanh cong");
    }

    // DELETE: api/students/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok("Xoa thanh cong");
    }

    [HttpGet("Search")] 
    public IActionResult Search(string name)
    {
        return Ok(_repo.SearchByName(name));
    }

    [HttpGet("course")] 
    public IActionResult getAllWithCourese() {
        return Ok(_repo.getAllWithCourse());
    }
}