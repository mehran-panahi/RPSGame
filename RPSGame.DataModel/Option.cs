using RPSGame.Entity.Enums;

namespace RPSGame.Entity
{
    public struct Option : IEquatable<Option>
    {
        public OptionTypes Type { get; private set; }

        public OptionTypes[] Beats { get; private set; }

        public Option(OptionTypes type, params OptionTypes[] beats)
        {
            Type = type;
            Beats = beats;
        }


        public override string ToString() =>  Enum.GetName(typeof(OptionTypes), Type);

        public bool Beat(Option other)
        {
            return Beats.Contains(other.Type);
        }
        
        public bool Equals(Option other) => Type == other.Type;
       
        public static bool operator ==(Option option, Option other) => option.Equals(other);

        public static bool operator !=(Option option, Option other) => !option.Equals(other);

        public static Option Default => new Option(OptionTypes.None, OptionTypes.None);
    }
}
