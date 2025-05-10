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

    public void DisplayAllEnrollments() {
        var studentWithCourses = _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();

        if (!studentWithCourses.Any())
        {
            Console.WriteLine("No students found.");
            return;
        }
        
        foreach (var student in studentWithCourses) 
        {
            Console.WriteLine($"\nStudent: {student.Name} ({student.Email})");
            if (student.Enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments.");
            }
            else 
            {
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($" - {enrollment.Course.Name} ({enrollment.Course.Credits} credits)");
                }
            }
        }
    }
}
