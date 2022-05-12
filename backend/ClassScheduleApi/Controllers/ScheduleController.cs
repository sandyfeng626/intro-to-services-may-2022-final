using ClassScheduleApi.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduleApi.Controllers;

[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleAdapter _adapter;

    public ScheduleController(ScheduleAdapter adapter)
    {
        _adapter = adapter;
    }

    [HttpGet]
    public async Task<ActionResult> GetSchedule()
    {
        var data = _adapter.GetSchedule();

        return Ok(new { data });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetScheduleForClass(string id)
    {
        var response = _adapter.GetForClass(id);
        return response switch
        {
            null => NotFound(),
            _ => Ok(new { course = id, data = response }),
        };
    }
}
