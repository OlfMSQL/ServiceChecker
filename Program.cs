using System;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Threading;

   public class WebsiteReachabilityChecker
{
    public static async Task<bool> IsWebsiteReachable(string url)
    {
        using (var client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
public class Program
{
    public static async Task Main()
    {
        string DiscordURL = "https://discordstatus.com/";
        string TeamSpeakURL = "https://www.teamspeak.com/";
        string googleURL = "https://google.com";

        bool DCReachable = await WebsiteReachabilityChecker.IsWebsiteReachable(DiscordURL);
        bool TSreachable = await WebsiteReachabilityChecker.IsWebsiteReachable(TeamSpeakURL);
        bool googlereachable = await WebsiteReachabilityChecker.IsWebsiteReachable(googleURL);

        Console.WriteLine("=======================================================");

        Console.WriteLine($"Discord reachable: {DCReachable}");
        Console.WriteLine($"Google reachable: {googlereachable}");
        Console.WriteLine($"TeamSpeak reachable: {TSreachable}");
        
        Console.WriteLine("=======================================================");
    }
}
