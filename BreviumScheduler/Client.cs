using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BreviumScheduler
{
    static class Client
    {
        const string baseURI = "http://scheduling-interview-2021-265534043.us-west-2.elb.amazonaws.com/api/Scheduling";
        const string tokenQuery = "?token=82426b57-9a19-49af-bb04-e26f2d0249ee";
        static HttpClient client = new HttpClient();

        public static async Task<HttpStatusCode> StartSchedule()
        {
            HttpResponseMessage response = await client.PostAsync(baseURI + "/Start" + tokenQuery, new StringContent(""));
            return response.StatusCode;
        }

        public static async Task StopSchedule()
        {
            HttpResponseMessage response = await client.PostAsync(baseURI + "/Stop" + tokenQuery, new StringContent(""));
            var responseStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }

        public static async Task<ApptRequest> GetApptRequest()
        {
            ApptRequest apptRequest = null;
            HttpResponseMessage response = await client.GetAsync(baseURI + "/AppointmentRequest" + tokenQuery);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var respStream = await response.Content.ReadAsStreamAsync();
                var streamReader = new StreamReader(respStream);
                var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    apptRequest = serializer.Deserialize<ApptRequest>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else if (response.StatusCode != HttpStatusCode.NoContent)
            {
                Console.WriteLine("Request was unsuccessful.");
            }
            return apptRequest;
        }

        public static async Task<Appointment[]> GetSchedule()
        {
            Appointment[] schedule = null;
            HttpResponseMessage response = await client.GetAsync(baseURI + "/Schedule" + tokenQuery);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var respStream = await response.Content.ReadAsStreamAsync();
                var streamReader = new StreamReader(respStream);
                var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    schedule = serializer.Deserialize<Appointment[]>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("Request was unsuccessful.");
            }
            return schedule;
        }
    }
}
