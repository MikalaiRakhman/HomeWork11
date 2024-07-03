namespace HomeWork11.Exeptions
{
    public class EmptyListOfRewardsException : Exception
    {
        public EmptyListOfRewardsException() : base("List of Rewards is Empty!") 
        {

        }
    }
}
