namespace StudentCourseEnrollment;

public interface IEnrollmentService
{
    bool EnrollStudent(int studentId, int courseId);
    IEnumerable<Enrollment> GetAllEnrollments();
    Enrollment? GetEnrollment(int studentId, int courseId);
}