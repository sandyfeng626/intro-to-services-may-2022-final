namespace ClassScheduleApi.Controllers;

[Route("schedule")]
public class ScheduleController : ControllerBase
{

    private readonly FileScheduleAdapter _fileScheduleAdapter;

    public ScheduleController(FileScheduleAdapter fileScheduleAdapter)
    {
        _fileScheduleAdapter = fileScheduleAdapter;
    }

    [HttpGet]
    public async Task<ActionResult> GetTheSchedule()
    {
        var response = _fileScheduleAdapter.GetClassList();
        return Ok(response);
        
    }

    // GET /schedule/393893893
    [HttpGet("{courseId}")]
    public async Task<ActionResult> GetAClassSchedule(string courseId)
    {
        var response = _fileScheduleAdapter.GetScheduleForClass(courseId);

        return response switch
        {
            null => NotFound(),
            _ => Ok(new { data = response })
        };

    }
}
