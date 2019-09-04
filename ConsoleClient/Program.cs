using MessagePack;
using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await GetTest();
        }

        private static async Task GetTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:5001/");

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-msgpack"));
                var response = await httpClient.GetAsync("api/customers");
                var bytes = await response.Content.ReadAsByteArrayAsync();

                // add package MessagePack
                var customers = MessagePackSerializer.Deserialize<IEnumerable<Customer>>(bytes);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.LastName);
                }
            }
        }
    }
}
