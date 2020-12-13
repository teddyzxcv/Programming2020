using System;
using System.Collections.Generic;
using System.Linq;

public partial class TestSystem
{
    public static List<User> UserList = new List<User>();

    public static List<User> EventList = new List<User>();
    public void Add(string username)
    {
        User newuser = new User(username);
        if (EventList.Contains(newuser))
            throw new ArgumentException("User already exists");
        if (!UserList.Contains(newuser))
        {
            UserList.Add(newuser);
            EventList.Add(UserList[UserList.Count - 1]);
            Notifications += UserList[UserList.Count - 1].SendMessage;
        }
        else
        {
            EventList.Add(UserList.Find(o => o.Name == username));
            Notifications += (UserList.Find(o => o.Name == username)).SendMessage;
        }

    }

    public void Remove(string username)
    {
        User deleteuser = new User(username);
        if (!EventList.Contains(deleteuser))
            throw new ArgumentException("User does not exist");
        EventList.Remove(EventList.Find(o => o.Name == username));
        Notifications -= (UserList.Find(o => o.Name == username)).SendMessage;
    }


}