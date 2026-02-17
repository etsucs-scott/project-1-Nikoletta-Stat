namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        public const int baseHealth = 100;
        public int Health { get; private set; }

        public int xPos { get; set; }
        public int yPos { get; set; }

        public int damage { get; set; }

        public int BaseDamage { get; private set; } = 10;

        public Player()
        {
            Health = baseHealth;
            xPos = 1;
            yPos = 1;
            damage = BaseDamage;
        }

        public List<Item> Inventory = new List<Item>();
        public void Attack(ICharacter target)
        {
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void PickUpItem (Item item)
        {
            if (item is Potion potion)
                Heal(potion);
            else
                Inventory.Add(item);
        }

        public int GetHighestModifier ()
        {
            int highestMod = 0;
            foreach (Item item in Inventory)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.modifier > highestMod)
                        highestMod = weapon.modifier;
                }
            }
            return highestMod;
        }

        public void Heal (Potion potion)
        {
            Health += potion.potionHealth;
            if (Health > baseHealth)
                Health = baseHealth;
        }
    }
}
