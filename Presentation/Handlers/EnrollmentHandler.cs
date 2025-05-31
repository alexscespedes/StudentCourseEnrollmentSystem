namespace StudentCourseEnrollment;

public class EnrollmentHandler()
{
    public static void Handle(IEnrollmentService enrollmentService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("== Enrollment Management ==");
            Console.WriteLine("1. Enroll Student in Course");
            Console.WriteLine("2. List Enrollments");
            Console.WriteLine("3. View Enrollment by Student and Course");
            Console.WriteLine("0. Back");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var (studentId, courseId) = EnrollmentConsoleHelper.PromptEnrollmentData();
                    enrollmentService.EnrollStudent(studentId, courseId);
                    break;
                case "2":
                    var enrollments = enrollmentService.GetAllEnrollments();
                    EnrollmentConsoleHelper.DisplayEnrollments(enrollments);
                    break;
                case "3":
                    EnrollmentConsoleHelper.SelectEnrollment(enrollmentService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}