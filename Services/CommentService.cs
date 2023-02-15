using System.Globalization;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using RestSharp;

namespace Services;

public class CommentService : ICommentService
{
    private readonly IConfiguration _configuration;

    public CommentService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Comment>> getComments()
    {
        string url = _configuration["CommentsURI"];
        var client = new RestClient(url);
        var request = new RestRequest();
        var response = await client.GetAsync<IEnumerable<Comment>>(request);
        var json = JsonConvert.SerializeObject(response);
        var data = JsonConvert.DeserializeObject<IEnumerable<Comment>>(json);
        var body = data.Select(x => 
            new Comment()
            {
                body = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(x.body), name = x.name,
                email = x.email, id = x.id, postId = x.postId
            }).ToList();
        return body;
    }

    public async Task<IEnumerable<Comment>> searchByNameOrBody(string name, string body)
    {
        var data = await getComments();
        if (!string.IsNullOrEmpty(name))
            data = data.Where(x => x.name!.Contains(name));
        if (!string.IsNullOrEmpty(body))
            data = data.Where(x => x.body!.Contains(body));
        return data;
    }
}