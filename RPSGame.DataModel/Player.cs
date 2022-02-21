namespace RPSGame.Entity
{
    public abstract class Player
    {
        public Guid Guid { get; private set; } = new Guid();

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Option CurrentChoice { get; protected set; }

        public abstract Option Guess();


        public int Score { get; private set; }

        public void AddScore()
        {
            Score++;
        }

        public override string ToString() => $"{Name} : has { Score } Score ";
        
    }
}
