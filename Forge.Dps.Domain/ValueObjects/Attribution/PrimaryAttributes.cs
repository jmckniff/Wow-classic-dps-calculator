namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class PrimaryAttributes
    {
        public Strength Strength { get; protected set; }
        public Agility Agility { get; protected set; }
        public Stamina Stamina { get; protected set; }
        public Intellect Intellect { get; protected set; }
        public Spirit Spirit { get; protected set; }

        public PrimaryAttributes()
        {
            Strength = Strength.Zero;
            Agility = Agility.Zero;
            Stamina = Stamina.Zero;
            Intellect = Intellect.Zero;
            Spirit = Spirit.Zero;
        }

        public PrimaryAttributes(
            Strength strength,
            Agility agility,
            Stamina stamina,
            Intellect intellect,
            Spirit spirit)
        {
            Strength = strength;
            Agility = agility;
            Stamina = stamina;
            Intellect = intellect;
            Spirit = spirit;

        }

        public PrimaryAttributes(double strength, double agility, double stamina, double intellect, double spirit)
        {
            Strength = new Strength(strength);
            Agility = new Agility(agility);
            Stamina = new Stamina(stamina);
            Intellect = new Intellect(intellect);
            Spirit = new Spirit(spirit);
        }

        public PrimaryAttributes Combine(PrimaryAttributes attributes)
        {
            return new PrimaryAttributes(
                new Strength(Strength.Value + attributes.Strength.Value), 
                new Agility(Agility.Value + attributes.Agility.Value),
                new Stamina(Stamina.Value + attributes.Stamina.Value),
                new Intellect(Intellect.Value + attributes.Intellect.Value),
                new Spirit(Spirit.Value + attributes.Spirit.Value)
            );
        }

    }
}
