namespace StudentCourseEnrollment;

public class Course {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
