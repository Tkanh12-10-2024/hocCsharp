namespace hocCsharp.Arrays;
using System;
public class Mang
{
    static void Main()
    {
        List<string> listString = new List<string>
        {
            "Name",
            "User",
            "Password",
            "Acount",
        };
        listString.Add("counting");
        listString.RemoveAt(2);
        listString.Sort();
        Console.WriteLine($"List String: {string.Join(",",listString)}");

    }
    
}
