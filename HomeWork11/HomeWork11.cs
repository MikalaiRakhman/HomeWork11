namespace HomeWork11;
class HomeWork11
{
    static void Main (string[] args)
    {
        Server server = new Server();        

        Client client = new Client();

        server.BoxesCreated += () => Console.WriteLine("Server create new list of boxes");
        try
        {
            var c = client.SortBoxes(server.CreateListOfBoxes());

            var str = client.ShowInformationAboutBoxes(c);

            Console.WriteLine(str);
        }

        catch (ArgumentNullException ex) 
        {
            Console.WriteLine("Ошибка 1: ссылка на список равна null");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка 2: список сундоков пуст");
        }
        finally
        {
            Console.WriteLine("ИГРА ОКОНЧЕНА!");
        }        

        Console.ReadLine ();
    }
}