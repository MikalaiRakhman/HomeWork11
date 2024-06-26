namespace HomeWork11;
class HomeWork11
{
    static void Main (string[] args)
    {
        Server server = new Server();
        var s = server.CreateListOfBoxes();
        Client client = new Client();
        var c = client.SortBoxes(s);

        var str = client.ShowInformationAboutBoxes(c);
        


        Console.WriteLine (str);

        Console.ReadLine ();
    }
}