using System.Text.RegularExpressions;

namespace StudentCourseEnrollment;

public class StudentService {
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context) {
        _context = context;
    }

    public bool RegisterStudent(string name, string email, DateTime dateOfBirth) {
        if (!IsValidEmail(email))
        {
            Console.WriteLine("Invalid email format.");
            return false;
        }

        if (_context.Students.Any(s => s.Email == email))
        {
            Console.WriteLine("A student with this email already exists.");
            return false;
        }

        var student = new Student {
            Name = name,
            Email = email,
            DateOfBirth = dateOfBirth
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        Console.WriteLine("Student registered successfully.");
        return true;
    }

    private bool IsValidEmail(string email) {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }
}
