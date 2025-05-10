namespace StudentCourseEnrollment;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        var studentService = new StudentService(context);
        var courseService = new CourseService(context);

        bool exit = false;

        while(!exit) {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     Welcome to the Enrollment System   ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Register a Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Add a Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. View Enrollments");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    RegisterStudent(studentService);
                    break;

                case "2":
                    Console.WriteLine("Viewing all students (feature to be implemented)...");
                    break;
                case "3":
                    AddCourse(courseService);
                    break;
                case "4":
                    Console.WriteLine("Enrolling student (feature to be implemented)...");
                    break;
                case "5":
                    Console.WriteLine("Viewing enrollments (feature to be implemented)...");
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Pause();
                    break;
            }
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
            Pause();
        }

        void AddCourse(CourseService service) {
            Console.Clear();
            Console.WriteLine("== Register a New Student ==");

            Console.Write("Course Name: ");
            string name = Console.ReadLine()!;

            
            Console.Write("Credits (e.g., 3): ");
            int credits;
            while (!int.TryParse(Console.ReadLine(), out credits) || credits <= 0) {
                Console.Write("Invalid number. Try again: ");
            }

            service.AddCourse(name, credits);
            Pause();
        }

        void Pause() {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
