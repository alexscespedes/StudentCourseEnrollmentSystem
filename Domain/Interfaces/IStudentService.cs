namespace StudentCourseEnrollment;

public interface IStudentService
{
    bool RegisterStudent(string name, string email, DateTime dob);
    List<Student> GetAllStudents();
    Student? GetStudentById(int id);
    // void UpdateStudent(Student student);
    // void DeleteStudent(int id);
}