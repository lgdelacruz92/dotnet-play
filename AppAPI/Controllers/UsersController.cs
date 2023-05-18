using Microsoft.AspNetCore.Mvc;
using AppAPI.Models;
using Couchbase.Extensions.DependencyInjection;

namespace AppAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly INamedBucketProvider _bucketProvider;

    public UsersController(INamedBucketProvider bucketProvider)
    {
        _bucketProvider = bucketProvider;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _bucketProvider.GetBucketAsync();
        return Ok(users);
    }

}