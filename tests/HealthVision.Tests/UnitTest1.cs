using HealthVision.API.Controllers;
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
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1986, 5, 10),
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

        var result = await controller.GetPatient(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreatePatient_ReturnsCreatedPatient()
    {
        await using var context = CreateContext();

        var controller = new PatientsController(context);

        var patient = new Patient
        {
            Id = 1,
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = new DateTime(1991, 8, 15),
            Gender = "Female"
        };

        var result = await controller.CreatePatient(patient);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        Assert.Equal(
            nameof(PatientsController.GetPatient),
            createdResult.ActionName);

        Assert.Equal(patient, createdResult.Value);

        var savedPatient = await context.Patients.FindAsync(patient.Id);

        Assert.NotNull(savedPatient);
        Assert.Equal("Jane", savedPatient.FirstName);
        Assert.Equal("Doe", savedPatient.LastName);
    }
}
