using AcademyA.Biblioteca.Client.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcademyA.Biblioteca.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string baseAPIUrl = "https://localhost:44370/api/Books";

            Console.WriteLine("==== TEST HTTPCLIENT ====");

            HttpClient client = new HttpClient();

            #region POST

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseAPIUrl)
            };

            BookContract bookData = new BookContract
            {
                ISBN = "6575-090874783-098",
                Title = "Faust",
                Summary = "Il mattone",
                Author = "J. W. Goethe"
            };
            string bookDataAsString = JsonConvert.SerializeObject(bookData);
            request.Content = new StringContent(
                bookDataAsString,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response;   // = await client.SendAsync(request);

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var item = JsonConvert
            //        .DeserializeObject<BookContract>(jsonData);

            //    Console.WriteLine($"[{item.ISBN}] {item.Title} ({item.Author})");
            //}

            #endregion

            #region GET

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseAPIUrl)
            };

            response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert
                    .DeserializeObject<List<BookContract>>(jsonData);

                foreach (var item in data)
                    Console.WriteLine($"[{item.ISBN}] {item.Title} ({item.Author})");
            }

            #endregion            

            #region GET BY ID

            Console.Write("ID: ");
            string id = Console.ReadLine();

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseAPIUrl}/{id}")
            };

            response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var item = JsonConvert
                    .DeserializeObject<BookContract>(jsonData);

                Console.WriteLine("--- GET BY ID ---");
                Console.WriteLine($"[{item.ISBN}] {item.Title} ({item.Author})");
            }

            #endregion
        }
    }
}
