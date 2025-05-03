namespace StudentCourseEnrollment;

public class Student {
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
