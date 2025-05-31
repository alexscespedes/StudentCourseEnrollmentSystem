namespace StudentCourseEnrollment;

public static class StudentHandler
{
    public static void Handle(IStudentService studentService)
    {
        
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("== Student Management ==");
            Console.WriteLine("1. Register New Student");
            Console.WriteLine("2. List All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("0. Back");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var newStudent = StudentConsoleHelper.PromptStudentData();
                    studentService.RegisterStudent(newStudent.Name, newStudent.Email, newStudent.DateOfBirth);
                    break;

                case "2":
                    var students = studentService.GetAllStudents();
                    StudentConsoleHelper.DisplayStudents(students);
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