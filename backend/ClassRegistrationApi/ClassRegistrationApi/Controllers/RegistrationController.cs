using ClassRegistrationApi.Domain;
using ClassRegistrationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistrationApi.Controllers;

[Route("registrations")]
[ApiController]
public class RegistrationController : ControllerBase
{

    private readonly ILookupCourseSchedules _scheduleLookup;
    private readonly ICreateReservations _reservationCreator;

    public RegistrationController(ILookupCourseSchedules scheduleLookup, ICreateReservations reservationCreator)
    {
        _scheduleLookup = scheduleLookup;
        _reservationCreator = reservationCreator;
    }

    [HttpPost]
    public async Task<ActionResult<Models.Registration>> AddARegistration([FromBody] RegistrationRequest request)
    {
        // If the thing is valid...
        // --- Validate that the course is offered on the date.
        // Write the Code You Wish You Had
        var dateOfCourse = request.DateOfCourse!.Value;
        bool courseIsAvailableOnThatDate = await _scheduleLookup.CourseAvailabeAsync(request.Course, dateOfCourse);
        if(!courseIsAvailableOnThatDate)
        {
            return BadRequest("Sorry, that course isn't available then.");
        }
        //var response = new Models.Registration("99", request);
        Models.Registration response = await _reservationCreator.CreateReservationForAsync(request);

        return Ok(response);

    }
}

