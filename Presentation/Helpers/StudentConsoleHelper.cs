namespace StudentCourseEnrollment;

public static class StudentConsoleHelper
{
    public static void DisplayStudents(IEnumerable<Student> students)
    {
        Console.WriteLine("-- Students --");
        foreach (var student in students)
        {
            Console.WriteLine($"[{student.Id}] {student.Name} - {student.Email} - {student.DateOfBirth.ToShortDateString()}");
        }
    }

    public static Student PromptStudentData()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Date of Birth (yyyy-mm-dd): ");
        var dob = DateTime.Parse(Console.ReadLine()!);

        return new Student
        {
            Name = name,
            Email = email,
            DateOfBirth = dob
        };
    }

    public static Student? SelectStudent(IStudentService service)
    {
        var students = service.GetAllStudents();
        DisplayStudents(students);
        Console.Write("Enter student ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            return service.GetStudentById(id);
        }
        Console.WriteLine("Invalid ID.");
        return null;
    }
}