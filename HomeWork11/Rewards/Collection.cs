namespace HomeWork11.Rewards
{
    public class Collection : IReward
    {
        public int Id { get; set; }
        public RewardTypes Type => RewardTypes.Collection;
    }
}
