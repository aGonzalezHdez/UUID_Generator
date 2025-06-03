using Microsoft.AspNetCore.Mvc;
using UUID_Generator.Services;

namespace AWS_UUID_Generator.Controllers;

[ApiController]
[Route("[controller]")]
public class UuidGeneratorController : ControllerBase
{
    [HttpGet("v4")]
    public Guid GenerateUuidV4(string seed)
    {
        return UUIDGenerator.GenerateV4(seed);
    }
    
    [HttpGet("v5")]
    public Guid GenerateUuidV5(string seed)
    {
        return UUIDGenerator.GenerateV5(seed);
    }
    
    
    
    
}