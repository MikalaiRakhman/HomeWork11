namespace HomeWork11
{
    public class Collection
    {
        public int Id
        {
            get 
            {
                return Id; 
            }
            set 
            { 
                if (value >= 1 && value <= 10)
                {
                    Id = value;
                }                
            }
        }        
        
        public Collection(int id)
        {
            Id = id;
        }
    }
}
