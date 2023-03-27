using Microsoft.AspNetCore.Mvc;

public class TestController : ControllerBase { 
    [HttpGet("/test")] 
    public ActionResult Index() 
    { 
        return Ok();
    } 
}