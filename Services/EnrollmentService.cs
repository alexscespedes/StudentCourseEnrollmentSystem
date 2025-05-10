using Microsoft.EntityFrameworkCore;

namespace StudentCourseEnrollment;

public class EnrollmentService {
    private readonly AppDbContext _context;

    public EnrollmentService(AppDbContext context) {
        _context = context;
    }

    public bool EnrollStudent(int studentId, int courseId) {
        var student = _context.Students.Include(s => s.Enrollments).FirstOrDefault(s => s.Id == studentId);

        var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

        if (student == null)
        {
            Console.WriteLine("Student not found");
        }

        if (course == null)
        {
            Console.WriteLine("Course not found");
        }

        bool alreadyEnrolled = _context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);

        if (alreadyEnrolled)
        {
            Console.WriteLine("Student is already enrolled in this course.");
            return false;
        }

        var enrollment = new Enrollment {
            StudentId = studentId,
            CourseId = courseId
        };

        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();

        Console.WriteLine("Enrollment succesful.");
        return true;
    }

    public List<Student> GetAllStudents() => _context.Students.ToList();
    public List<Course> GetAllCourses() => _context.Courses.ToList();
}
