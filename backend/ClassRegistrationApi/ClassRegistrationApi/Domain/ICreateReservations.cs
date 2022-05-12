using ClassRegistrationApi.Models;

namespace ClassRegistrationApi.Domain;

public interface ICreateReservations
{
    Task<Models.Registration> CreateReservationForAsync(RegistrationRequest request);
}
