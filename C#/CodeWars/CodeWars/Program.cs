using CodeWars.Challenges;

namespace CodeWars;

class Program
{
    static void Main(string[] args)
    {
        var thing = HumanReadableDurationFormat.FormatDuration(15731080);
        Console.WriteLine(thing);
    }
}