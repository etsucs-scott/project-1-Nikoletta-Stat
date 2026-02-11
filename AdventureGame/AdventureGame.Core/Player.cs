namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        public int Health { get; set; } = 100;
        public int damage { get; set; } = 10;

        public void Attack(ICharacter target)
        {
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
