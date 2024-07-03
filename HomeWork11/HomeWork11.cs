using HomeWork11.Exceptions;
using HomeWork11.Exeptions;

namespace HomeWork11;
class HomeWork11
{
    static void Main(string[] args)
    {
        try
        {
            Server server = new Server();

            Client client = new Client();

            server.ChestsCreated += client.Recive;

            server.Send();
        }

        catch (NullListOfRewardsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (EmptyListOfRewardsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("ИГРА ОКОНЧЕНА!");
        }

        Console.ReadLine();
    }
}