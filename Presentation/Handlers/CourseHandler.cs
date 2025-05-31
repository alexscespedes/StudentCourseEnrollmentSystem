namespace StudentCourseEnrollment;

public class CourseHandler
{
    public static void Handle(ICourseService courseService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("== Course Management ==");
            Console.WriteLine("1. Add New Course");
            Console.WriteLine("2. List All Courses");
            Console.WriteLine("3. Update Course");
            Console.WriteLine("4. Delete Course");
            Console.WriteLine("0. Back");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var newCourse = CourseConsoleHelper.PromptCourseData();
                    courseService.AddCourse(newCourse.Name, newCourse.Credits);
                    break;
                case "2":
                    var courses = courseService.GetAllCourses();
                    CourseConsoleHelper.DisplayCourses(courses);
                    break;
                case "3":

                    break;
                case "4":

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