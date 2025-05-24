namespace StudentCourseEnrollment;

public interface IEnrollmentService
{
    bool EnrollStudent(int studentId, int courseId);
    void DisplayAllEnrollments();
    // List<Student> GetAllStudents();
    // List<Course> GetCourses();
}