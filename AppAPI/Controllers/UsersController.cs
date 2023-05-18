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
    [Route("{Id}")]
    public async Task<IActionResult> Get([FromRoute] string Id)
    {
        var bucket = await _bucketProvider.GetBucketAsync();
        var collection = await bucket.DefaultCollectionAsync();
        var users = await collection.GetAsync(Id);

        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> put([FromBody] User user)
    {
        var bucket = await _bucketProvider.GetBucketAsync();
        var collection = await bucket.DefaultCollectionAsync();

        // defaulting the id value to insert. New Id generation has different approaches which is not discussed here.
        user.Name = "Lester";

        // using the collection object insert the new airport object
        await collection.InsertAsync<User>($"airport_{user.Id}", user);
        return Ok(user);
    }

}