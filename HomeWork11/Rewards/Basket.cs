namespace HomeWork11.Rewards
{
    public class Basket : IReward
    {
        public List<IReward> Rewards = new List<IReward>();
        public RewardTypes Type => RewardTypes.Basket;
    }
}
