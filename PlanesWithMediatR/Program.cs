using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace PlanesWithMediatR
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var mediator = BuildMediator();

            AirplaneBase airbusAirplane = new AirbusAirplane(mediator);
            BoeingAirplane boeingAirplane = new BoeingAirplane(mediator);

            airbusAirplane.Send("Can we land right now ?");
            Console.WriteLine("----------");

            boeingAirplane.Send("No! We're landing, wait ...");
            Console.WriteLine("----------");

            // Demonstrate landing ...
            Console.WriteLine("Boeing is landing ...");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("----------");

            boeingAirplane.Send("We landed.");
            Console.WriteLine("----------");

            airbusAirplane.Send("OK, We're going to land ...");
            Console.WriteLine("----------");

            boeingAirplane.Send("Good luck.");

            Console.ReadKey();
        }

        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            services.AddMediatR(typeof(NotificationMessage));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }
    }
}
