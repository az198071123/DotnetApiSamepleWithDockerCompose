
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

[Route("api/[controller]")]
[ApiController]
public class RedisController : ControllerBase
{
    private readonly IConnectionMultiplexer _redis;

    public RedisController(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        var db = _redis.GetDatabase();
        var foo = await db.StringGetAsync("test");
        return Ok(foo.ToString());
    }
}