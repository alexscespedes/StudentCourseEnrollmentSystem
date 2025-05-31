namespace StudentCourseEnrollment;

public interface IStudentService
{
    void RegisterStudent(string name, string email, DateTime dob);
    List<Student> GetAllStudents();
    Student? GetStudentById(int id);
    // void UpdateStudent(Student student);
    // void DeleteStudent(int id);
}