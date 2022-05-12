using ClassRegistrationApi.Adapters;
using ClassRegistrationApi.Models;

namespace ClassRegistrationApi.Domain;

// Transient/Scoped
public class MongoReservationProcessor : ICreateReservations
{
    // Singleton 
    private readonly RegistrationMongoAdapter _adapter;

    public MongoReservationProcessor(RegistrationMongoAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<Models.Registration> CreateReservationForAsync(RegistrationRequest request)
    {
        var registration = new Registration
        {
            Details = new RegistrationDetails
            {
                Course = request.Course,
                DateOfCourse = request.DateOfCourse!.Value,
                Name = request.Name
            }
        };

        await _adapter.GetRegistrationCollection().InsertOneAsync(registration);

        return new Models.Registration(registration.Id.ToString(), new RegistrationRequest { 
            Course = registration.Details.Course, 
            DateOfCourse = registration.Details.DateOfCourse, 
            Name = registration.Details.Name });
    }
}
