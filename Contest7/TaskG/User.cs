using System;
using System.Collections.Generic;

public class User
{

    public string Name;
    public User(string username)
    {
        this.Name = username;
    }
    private List<string> messagearchive = new List<string>();

    public override string ToString() => Name;

    public override bool Equals(object obj)
    {
        return this.Name == ((User)obj).Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void SendMessage(string text)
    {
        Console.WriteLine($"-{this.Name}-");
        if (messagearchive.Count > 0)
        {
            Console.WriteLine("Received notifications:");
            for (int i = 0; i < messagearchive.Count; i++)
            {
                Console.WriteLine(messagearchive[i]);
            }
        }
        Console.WriteLine($"New notification: {text}");
        messagearchive.Add(text);
    }

}