using System.Text.RegularExpressions;

namespace StudentCourseEnrollment;

public class StudentService {
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context) {
        _context = context;
    }

    public List<Student> GetAllStudents() {
         return _context.Students.ToList();
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

    public bool EditStudent (int studentId, string? newName, string? newEmail, DateTime? newDob) {
        var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
        if (student == null)
        {
            Console.WriteLine("Student not found");
            return false;
        }

        if (!string.IsNullOrWhiteSpace(newEmail) && newEmail != student.Email)
        {
            if (!IsValidEmail(newEmail))
            {
                Console.WriteLine("Invalid email format.");
                return false;
            }
            if (_context.Students.Any(s => s.Email == newEmail && s.Id != studentId))
            {
                Console.WriteLine("Another student with this email already exists.");
                return false;
            }
            student.Email = newEmail;
        }

        if (!string.IsNullOrWhiteSpace(newName))
        {
            student.Name = newName;
        }

        if (newDob.HasValue)
        {
            student.DateOfBirth = newDob.Value;
        }

        _context.SaveChanges();
        Console.WriteLine("Student information updated successfully");
        return true;
    }

    private bool IsValidEmail(string email) {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }
}
