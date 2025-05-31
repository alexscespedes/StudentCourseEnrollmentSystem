using Microsoft.EntityFrameworkCore;

namespace StudentCourseEnrollment;

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite("Data Source=Database/student_course.db").Options;

        using var context = new AppDbContext(options);

        var studentService = new StudentService(context);
        var courseService = new CourseService(context);
        var enrollmentService = new EnrollmentService(context);

        while (true)
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
                    StudentHandler.Handle(studentService);
                    break;
                case "2":
                    CourseHandler.Handle(courseService);
                    break;
                case "3":
                    EnrollmentHandler.Handle(enrollmentService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Console.ReadKey();
                    break;
            }
        }

    }
}
