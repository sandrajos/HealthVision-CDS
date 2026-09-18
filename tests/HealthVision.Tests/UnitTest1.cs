using HealthVision.API.Controllers;
using HealthVision.Domain.Entities;
using HealthVision.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthVision.Tests;

public class PatientsControllerTests
{
    private static HealthVisionDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<HealthVisionDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new HealthVisionDbContext(options);
    }

    [Fact]
    public async Task GetPatients_ReturnsOkWithPatients()
    {
        await using var context = CreateContext();

        context.Patients.Add(new Patient
        {
            Id = Guid.NewGuid(),
            PatientNumber = "P001",
            Name = "John Doe",
            Age = 40,
            Gender = "Male"
        });

        await context.SaveChangesAsync();

        var controller = new PatientsController(context);

        var result = await controller.GetPatients();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var patients = Assert.IsAssignableFrom<IEnumerable<Patient>>(okResult.Value);

        Assert.Single(patients);
    }

    [Fact]
    public async Task GetPatient_ReturnsNotFound_WhenPatientDoesNotExist()
    {
        await using var context = CreateContext();

        var controller = new PatientsController(context);

        var result = await controller.GetPatient(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreatePatient_ReturnsCreatedPatient()
    {
        await using var context = CreateContext();

        var controller = new PatientsController(context);

        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            PatientNumber = "P002",
            Name = "Jane Doe",
            Age = 35,
            Gender = "Female"
        };

        var result = await controller.CreatePatient(patient);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        Assert.Equal(nameof(PatientsController.GetPatient), createdResult.ActionName);
        Assert.Equal(patient, createdResult.Value);

        var savedPatient = await context.Patients.FindAsync(patient.Id);

        Assert.NotNull(savedPatient);
        Assert.Equal("Jane Doe", savedPatient.Name);
    }
}
