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

        // Attack() is called from Game.Battle()
        public void Attack(ICharacter target) 
        {
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        // PickUpItem() adds weapons to inventory list and calls the Heal() method.
        public void PickUpItem (Item item)
        {
            if (item is Potion potion)
                Heal(potion);
            else
                Inventory.Add(item);
        }

        // Checks each weapon in inventory and returns the highest modifier integer.
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

        // Adds HP to player's health.
        public void Heal (Potion potion)
        {
            Health += potion.potionHealth;
            if (Health > baseHealth)
                Health = baseHealth;
        }
    }
}
