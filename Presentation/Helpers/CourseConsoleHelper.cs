namespace StudentCourseEnrollment;

public static class CourseConsoleHelper
{
    public static void DisplayCourses(IEnumerable<Course> courses)
    {
        Console.WriteLine("-- Courses --");
        foreach (var course in courses)
        {
            Console.WriteLine($"[{course.Id}] {course.Name} - {course.Credits}");
        }
    }

    public static Course PromptCourseData()
    {
        Console.Write("Course Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Credits (e.g., 3): ");
        var credit = int.Parse(Console.ReadLine()!);

        return new Course
        {
            Name = name,
            Credits = credit,
        };
    }

    public static Course? SelectCourse(ICourseService service)
    {
        var courses = service.GetAllCourses();
        DisplayCourses(courses);
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            return service.GetCourseById(id);
        }
        Console.WriteLine("Invalid ID.");
        return null;
    }
}