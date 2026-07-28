namespace HealthVision.Domain.Entities;

public class Patient
{
    public Guid Id { get; set; }

    public string PatientNumber { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; }
}
