using Microsoft.EntityFrameworkCore;

namespace StudentCourseEnrollment;

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("StudentCourseEnrollmentDb").options;

        using var context = new AppDbContext(options);
        var studentService = new StudentService(context);
        var courseService = new CourseService(context);
        var enrollmentService = new EnrollmentService(context);

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     Welcome to the Student Course Enrollment System   ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Courses");
            Console.WriteLine("3. Manage Enrollments");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        void RegisterStudent(StudentService service) {
            Console.Clear();
            Console.WriteLine("== Register a New Student ==");

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.Write("Invalid format. Try again (yyyy-mm-dd)");
            }

            service.RegisterStudent(name, email, dob);
            
        }

        void AddCourse(CourseService service) {
            Console.Clear();
            Console.WriteLine("== Register a New Course ==");

            Console.Write("Course Name: ");
            string name = Console.ReadLine()!;

            
            Console.Write("Credits (e.g., 3): ");
            int credits;
            while (!int.TryParse(Console.ReadLine(), out credits) || credits <= 0) {
                Console.Write("Invalid number. Try again: ");
            }

            service.AddCourse(name, credits);
            
        }

        void EnrollStudentInCourse(EnrollmentService enrollmentService) {
            Console.Clear();
            Console.WriteLine("== Enroll Student in a Course ==");

            var students = studentService.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                
                return;
            }

            Console.WriteLine("\nStudents:");
            foreach (var s in students)
                Console.WriteLine($"{s.Id}. {s.Name} ({s.Email})");

            Console.Write("Enter Student ID: ");
            int studentId;
            while (!int.TryParse(Console.ReadLine(), out studentId) || !students.Any(s => s.Id == studentId)) {
                Console.Write("Invalid ID. Try again: ");
            }

            var courses = courseService.GetAllCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                
                return;
            }

            Console.WriteLine("\nCourses:");
            foreach (var c in courses)
                Console.WriteLine($"{c.Id}. {c.Name} ({c.Credits})");

            Console.Write("Enter Course ID: ");
            int courseId;
            while (!int.TryParse(Console.ReadLine(), out courseId) || !courses.Any(c => c.Id == courseId)) {
                Console.Write("Invalid ID. Try again: ");
            }

            enrollmentService.EnrollStudent(studentId, courseId);
            
        }
    }
}
