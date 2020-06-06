

using Microsoft.AspNetCore.Mvc;

public class ValuesController : BaseController {
    [HttpGet]
    public string Get() => "Identity.API Running.";
}
