namespace StudentCourseEnrollment;

public interface ICourseService
{
    bool AddCourse(string name, int credits);
    List<Course> GetAllCourses();
}