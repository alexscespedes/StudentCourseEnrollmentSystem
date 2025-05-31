using System.Text.RegularExpressions;

namespace StudentCourseEnrollment;

public class StudentService : IStudentService {
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context) {
        _context = context;
    }

    public List<Student> GetAllStudents() {
        return _context.Students.ToList();
    }

    public Student? GetStudentById(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    public void RegisterStudent(string name, string email, DateTime dateOfBirth)
    {
        if (!IsValidEmail(email))
        {
            Console.WriteLine("Invalid email format.");
        }

        if (_context.Students.Any(s => s.Email == email))
        {
            Console.WriteLine("A student with this email already exists.");
        }

        var student = new Student
        {
            Name = name,
            Email = email,
            DateOfBirth = dateOfBirth
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        Console.WriteLine("Student registered successfully.");
    }

    private bool IsValidEmail(string email) {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }
}
