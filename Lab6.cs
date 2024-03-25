using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Event myEvent = new Event(1, "Calgary");

        SerializeObject(myEvent, "event.txt");

        Event deserializedEvent = DeserializeObject("event.txt");
        Console.WriteLine(deserializedEvent.EventNumber);
        Console.WriteLine(deserializedEvent.Location);

        WriteAndReadFromFile("Hackathon");

    }

    static void SerializeObject(Event obj, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(obj.EventNumber);
            writer.WriteLine(obj.Location);
        }
    }

    static Event DeserializeObject(string filename)
    {
        Event obj = new Event();
        using (StreamReader reader = new StreamReader(filename))
        {
            obj.EventNumber = int.Parse(reader.ReadLine());
            obj.Location = reader.ReadLine();
        }
        return obj;
    }

    static void WriteAndReadFromFile(string word)
    {
        using (StreamWriter writer = new StreamWriter("event.txt", true))
        {
            writer.WriteLine(word);
        }

        string line;
        bool foundWord = false;

        using (StreamReader reader = new StreamReader("event.txt"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(word))
                {
                    foundWord = true;
                    int length = line.Length;

                    char firstChar = line[0];
                    char middleChar = line[length / 2];
                    char lastChar = line[length - 1];
                    
                    Console.WriteLine($"Tech Competition");
                    Console.WriteLine($"In Word: {word}");
                    Console.WriteLine($"The First Character is: \"{firstChar}\"");
                    Console.WriteLine($"The Middle Character is: \"{middleChar}\"");
                    Console.WriteLine($"The Last Character is: \"{lastChar}\"");

                    break;
                }
            }
        }

        if (!foundWord)
        {
            Console.WriteLine($"Word '{word}' not found in the file.");
        }
    }
}

class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }

    public Event(int eventNumber, string location)
    {
        EventNumber = eventNumber;
        Location = location;
    }

    public Event() { }
}