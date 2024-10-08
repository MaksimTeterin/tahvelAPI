namespace API.Data;
public class StudentHistory
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int StudyingYear { get; set; }
    public int GradesTotal { get; set; }
    public int NegativeGradesTotal { get; set; }
    public GradeTypes Type { get; set; }
    public DateOnly CreatedAt { get; set; }

    public StudentHistory()
    {
        this.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
    }
}
