using System;
using System.Collections.Generic;

internal class MyGiveawayHelper
{
    List<string> Prizes = new List<string>();


    List<string> Logins = new List<string>();
    string[] CoLogins;

    int numberstep = 1579;
    public MyGiveawayHelper(string[] logins, string[] prizes)
    {
        this.Prizes = new List<string>(prizes);
        this.Logins = new List<string>(logins);
        this.CoLogins = Logins.ToArray();


    }

    public bool HasPrizes
    {
        get
        {
            if (Prizes.Count == 0 || Logins.Count == 0)

                return false;

            else
                return true;
        }
    }
    public (string prize, string login) GetPrizeLogin()
    {
        numberstep = numberstep * numberstep % 1000000 / 100;
        string winnerlogin = Logins[numberstep % Logins.Count];
        string winnerprize = Prizes[0];
        Prizes.RemoveAt(0);
        return (winnerprize, winnerlogin);
    }
}