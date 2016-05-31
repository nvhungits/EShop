using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MyWebApiClient.Helpers
{
    public class WebApiClient<T>
    {
        public HttpClient client = new HttpClient();

        public WebApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:62387/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<T> GetAll(String requestUrl)
        {
            var response = client.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<List<T>>().Result;
                return students;
            }
            return null;
        }

        public T GetOne(String requestUrl)
        {
            var response = client.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var student = response.Content.ReadAsAsync<T>().Result;
                return student;
            }
            return default(T);
        }

        public List<T> Post(String requestUrl, object data)
        {
            var response = client.PostAsJsonAsync(requestUrl, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<List<T>>().Result;
                return students;
            }
            return null;
        }

        public bool Put(String requestUrl, object data)
        {
            var response = client.PutAsJsonAsync(requestUrl, data).Result;
            if (response.IsSuccessStatusCode)
            {
                //var students = response.Content.ReadAsAsync<List<Student>>().Result;
                //return students;
                return true;
            }
            //return null;
            return false;
        }

        public List<T> Delete(String requestUrl)
        {
            var response = client.DeleteAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<List<T>>().Result;
                return students;
            }
            return null;
        }
    }
}