using System.Globalization;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using RestSharp;

namespace Services;

public class PostService : IPostService
{
    private readonly IConfiguration _configuration;
    
    public PostService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Post>> getPosts()
    {
        string url = _configuration["PostsURI"];
        var client = new RestClient(url);
        var request = new RestRequest();
        var response = await client.GetAsync<IEnumerable<Post>>(request);
        var json = JsonConvert.SerializeObject(response);
        var data = JsonConvert.DeserializeObject<IEnumerable<Post>>(json);
        var body = data.Select(x => 
            new Post() { body = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(x.body), title = x.title}).ToList();
        return body;
    }
}