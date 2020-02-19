using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace web_test_api
{
    public interface IDependency
    {
        Task<string> getPost();
        Task<string> getUser();
    }

    public class Dependency : IDependency
    {

        HttpClient _client;
        private string guid { get; set; }

        public Dependency(HttpClient client)
        {
            _client = client;
            guid = Guid.NewGuid().ToString();
        }


        public async Task<string> getUser()
        {


            var result = await _client.GetStringAsync("/users");
            Console.WriteLine($"{guid} user");
            return result;
        }


        public async Task<string> getPost()
        {

            var result = await _client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            Console.WriteLine($"{guid} post");
            return result;
        }

    }

}