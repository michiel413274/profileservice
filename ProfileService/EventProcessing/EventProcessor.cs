using ProfileService.Models;
using System.Text.Json;

namespace ProfileService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.ProfilePublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventModel>(notificationMessage);
            Console.WriteLine(eventType.Event);
            switch(eventType.Event) 
            {
                case "Profile_Published":
                    Console.WriteLine("Profile published Event Detected");
                    return EventType.ProfilePublished;
                default:
                    Console.WriteLine("Could not determine event type");
                    return EventType.Undetermined;
            }
        }

        private void addPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                //var repo = scope.ServiceProvider.GetRequiredService<iprofileRepo>

                var profilePublishedDto = JsonSerializer.Deserialize<ProfileModel>(platformPublishedMessage);

                try
                {
                    if(profilePublishedDto != null) 
                    {
                        //repo.CreateProfile(profilePublishedDto);
                        //repo.SaveChanges();
                        Console.WriteLine("Profile added");
                    }
                    else
                    {
                        Console.WriteLine("profile already exists");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Could not add Profile to DB");
                }
            }
        }
    }
}