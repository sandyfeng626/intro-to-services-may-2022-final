



namespace ClassScheduleApi.Controllers;

public class StatusController : ControllerBase
{

    // GET /status
    [HttpGet("status")]
    public async Task<ActionResult> GetStatus()
    {
        // fake classroom stuff = go check the status somehow..
        var response = new StatusModel {  Message = "Looks good, Captain!", LastChecked= DateTime.Now };
        return Ok(response);
    }

}

