namespace StudentCourseEnrollment;
public class CourseService {
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context) {
        _context = context;
    }

    public bool AddCourse(string name, int credits) {
        if (_context.Courses.Any(c => c.Name.ToLower() == name.ToLower()))
        {
            Console.WriteLine("A course with this name already exists.");
            return false;
        }

        var course = new Course {
            Name = name,
            Credits = credits
        };

        _context.Courses.Add(course);
        _context.SaveChanges();

        Console.WriteLine("Course Added successfully.");
        return true;
    }
}