
using StudentAPI.Models;
using StudentManagementPro;

public interface IStudentService
{
    List<Student> GetAll();
    void Add(Student student);
    void Update(Student value);
    void DeleteSt(int id);
}
