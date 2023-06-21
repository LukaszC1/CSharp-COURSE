using Newtonsoft.Json;
using System.Text;
using System.Web;
using Flurl.Http;

namespace http
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var result2 = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                var json = await result2.Content.ReadAsStringAsync();


                var posts = JsonConvert.DeserializeObject<List<Post>>(json);
                var select = posts.FirstOrDefault(p=>p.id == 30);

                Console.WriteLine(select.title + "\n" + select.body);

                select.title = "Hello World";
                select.body = "This is a test";

                Console.WriteLine(select.title + "\n" + select.body);

                var postContent = new StringContent(JsonConvert.SerializeObject(select), Encoding.UTF8, "application/json");
                var postResult = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", postContent);

                Console.WriteLine(postResult.StatusCode);

                using (var postRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://jsonplaceholder.typicode.com/posts"))
                {
                    //postRequestMessage.Headers.Add("content-type", "application/json");
                    //postRequestMessage.Headers.Add("content-type", "application/json");

                    postRequestMessage.Content = postContent;
                    var post2Result = await client.SendAsync(postRequestMessage);
                }

                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                //adding the parameters
                queryParams["postId"] = "1";

                var formattedParams = queryParams.ToString();
                Console.WriteLine(formattedParams);
            }

            //get the data from server and deserialize it into list of posts
            var result = await "https://jsonplaceholder.typicode.com/posts".GetAsync()
                .ReceiveJson<List<Post>>();
          
            var select2 = result.FirstOrDefault(p => p.id == 30);
            Console.WriteLine(select2.title + "\n" + select2.body);

            select2.title = "Hello World";
            select2.body = "This is a test";

            var resultFlurl = await "https://jsonplaceholder.typicode.com/posts"
                .WithHeader("content-type", "application/json")
                .SetQueryParams(new {
                    postId = 1
                })
                .PostJsonAsync(select2);
      
            Console.WriteLine(resultFlurl.StatusCode);
        }
    }
}