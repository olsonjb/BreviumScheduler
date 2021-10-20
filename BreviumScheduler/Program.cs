using System;
using System.Threading.Tasks;
using System.Net;


namespace BreviumScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running scheduling application...");
            RunSchedulerAsync().GetAwaiter().GetResult();
        }

        static async Task RunSchedulerAsync()
        {
            HttpStatusCode startStatus = await Client.StartSchedule();
            if (startStatus.CompareTo(HttpStatusCode.OK) != 0)
            {
                Console.WriteLine("There was an error starting the scheduler.");
            }
            
            Appointment[] initSchedule = await Client.GetSchedule();
            Console.WriteLine("Retrieved schedule containing " + initSchedule.Length.ToString() + " appointments.");

            ApptRequest apptRequest = await Client.GetApptRequest();
            while (apptRequest != null)
            {
                Console.WriteLine("Retrieved Request " + apptRequest.RequestId.ToString());
                for (int i = 0; i < apptRequest.PreferredDays.Length; i++)
                {
                    for (int j = 0; j < apptRequest.PreferredDocs.Length; j++)
                    {
                        //Check constraints! As soon as a Doc and Date are found that meet those constraints, add to the schedule and break out of both for loops.
                    }
                }

                apptRequest = await Client.GetApptRequest();
            }

            await Client.StopSchedule();
        }
    }
}
