namespace StudentCourseEnrollment;

public static class EnrollmentConsoleHelper
{
    public static (int studentId, int courseId) PromptEnrollmentData()
    {
        Console.Write("Enter Student ID: ");
        var studentId = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Course ID: ");
        var courseId = int.Parse(Console.ReadLine()!);

        return (studentId, courseId);
    }

    public static void DisplayEnrollments(IEnumerable<Enrollment> enrollments)
    {
        Console.WriteLine("-- Enrollments --");
        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"The Student [{enrollment.Student.Name}] has enrolled [{enrollment.Course.Name}] with [{enrollment.Course.Credits}] Credits");
        }
    }

    public static Enrollment? SelectEnrollment(IEnrollmentService service)
    {
        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int StudentId))
        {
            Console.WriteLine("Invalid Student ID.");
            return null;
        }

        Console.Write("Enter Course ID: ");
        if (!int.TryParse(Console.ReadLine(), out int CourseId))
        {
            Console.WriteLine("Invalid Course ID.");
            return null;
        }

        var enrollment = service.GetEnrollment(StudentId, CourseId);
        if (enrollment == null)
        {
            Console.WriteLine("Enrollment not found.");
        }
        else
        {
            Console.WriteLine($"Enrollment found: Student Name = {enrollment.Student.Name}, Course Name = {enrollment.Course.Name}");
        }

        return enrollment;
    }
}