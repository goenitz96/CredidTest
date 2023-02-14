using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Services;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    
    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<User>> getUsers()
    {
        string url = _configuration["UsersURI"];
        var client = new RestClient(url);
        var request = new RestRequest();
        var response = await client.GetAsync<IEnumerable<User>>(request);
        var json = JsonConvert.SerializeObject(response);
        var data = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
        return data;
    }
}