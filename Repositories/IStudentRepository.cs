
using StudentAPI.Models;

public interface IStudentRepository
{
    List<Student> GetAll();
    void Add(Student student);
    void Update(Student student);
    void Delete(int id);
}
