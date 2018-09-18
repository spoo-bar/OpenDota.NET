using OpenDota.NET.Matches;
using System;

namespace OpenDotaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchManager = new MatchManager();
            matchManager.GetMatch(271145478);
            Console.WriteLine("Hello World!");
        }
    }
}
