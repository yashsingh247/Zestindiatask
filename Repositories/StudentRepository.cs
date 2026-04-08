using StudentAPI.Models;
using System.Data.SqlClient;
using System.Data;

public class StudentRepository : IStudentRepository
{
    private readonly string _conn = "Server=.;Database=StudentDB;Trusted_Connection=True;";

    public List<Student> GetAll()
    {
        var list = new List<Student>();

        using (SqlConnection con = new SqlConnection(_conn))
        {
            SqlCommand cmd = new SqlCommand("usp_GetStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Student
                {
                    Id = (int)dr["Id"],
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Age = (int)dr["Age"],
                    Course = dr["Course"].ToString()
                });
            }
        }
        return list;
    }

    // ✅ FIXED METHOD
    public void Add(Student value)
    {
        using (SqlConnection con = new SqlConnection(_conn))
        {
            SqlCommand cmd = new SqlCommand("usp_AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@Email", value.Email);
            cmd.Parameters.AddWithValue("@Age", value.Age);
            cmd.Parameters.AddWithValue("@Course", value.Course);
            cmd.Parameters.AddWithValue("@Actiont", "Add");

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public void Update(Student value)
    {
        using (SqlConnection con = new SqlConnection(_conn))
        {
            SqlCommand cmd = new SqlCommand("usp_AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", value.Id);
            cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@Email", value.Email);
            cmd.Parameters.AddWithValue("@Age", value.Age);
            cmd.Parameters.AddWithValue("@Course", value.Course);
            cmd.Parameters.AddWithValue("@Actiont", "Update");

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        using (SqlConnection con = new SqlConnection(_conn))
        {
            SqlCommand cmd = new SqlCommand("usp_AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Actiont", "Delete");

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}