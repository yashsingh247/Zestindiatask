
using StudentAPI.Models;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public List<Student> GetAll() => _repo.GetAll();

    public void Add(Student student)
    {
        student.CreatedDate = DateTime.Now;
        _repo.Add(student);
    }
    public void Update(Student student)
    {
        student.CreatedDate = DateTime.Now;
        _repo.Update(student);
    }

    public void DeleteSt(int id)
    {
       
        _repo.Delete(id);
    }

}
