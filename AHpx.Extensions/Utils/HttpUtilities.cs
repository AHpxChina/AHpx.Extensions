using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;

namespace AHpx.Extensions.Utils
{
    public static class HttpUtilities
    {
        private static readonly string UserAgent = $"AHpxExtensions/{ReflectionUtilities.GetAssemblyVersion()}";
        
        /// <summary>
        /// Send a GET request to specify url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return response;
        }

        /// <summary>
        /// Send a GET request with custom content-type
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAsync(string url, string contentType)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return response;
        }

        /// <summary>
        /// Send a GET request with custom headers
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers">Content-Type is available to add!</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAsync(string url, IEnumerable<(string, string)> headers)
        {
            (string, string)? contentType = null;
            var valueTuples = headers.ToList();
            
            if (valueTuples.Any(x => x.Item1 == "Content-Type"))
            {
                contentType = valueTuples.Single(x => x.Item1 == "Content-Type");

                valueTuples.Remove(contentType.Value);
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            foreach (var valueTuple in valueTuples)
            {
                client.DefaultRequestHeaders.Add(valueTuple.Item1, valueTuple.Item2);
            }

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (contentType.HasValue)
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType.Value.Item2);
            }

            return response;
        }

        /// <summary>
        /// Send a POST request with incoming json string
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostJsonAsync(string url, string json)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            var content = new StringContent(json, Encoding.Default, "application/json");
            
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return response;
        }

        /// <summary>
        /// Send a POST request with custom content type
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostJsonAsync(string url, string json, string contentType)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            var content = new StringContent(json, Encoding.Default,
                contentType.IsNullOrEmpty() ? "application/json" : contentType);

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return response;
        }

        /// <summary>
        /// Send a POST request with incoming json string
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="headers">Custom headers, Content-Type is available!</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostJsonAsync(string url, string json, IEnumerable<(string, string)> headers)
        {
            (string, string)? contentType = null;
            var valueTuples = headers.ToList();
            
            if (valueTuples.Any(x => x.Item1 == "Content-Type"))
            {
                contentType = valueTuples.Single(x => x.Item1 == "Content-Type");

                valueTuples.Remove(contentType.Value);
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            foreach (var valueTuple in valueTuples)
            {
                client.DefaultRequestHeaders.Add(valueTuple.Item1, valueTuple.Item2);
            }

            var content = new StringContent(json, Encoding.Default);

            if (contentType.HasValue)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType.Value.Item2);
            }

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}