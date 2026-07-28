namespace HealthVision.Domain.Entities;

public class Study
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public string Modality { get; set; }

    public string Status { get; set; }

    public DateTime CreatedDate { get; set; }
}
