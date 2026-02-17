namespace AdventureGame.Core
{
    public interface ICharacter
    {
        int Health { get; }
        int BaseDamage { get; }
        int damage { get; }
        void Attack(ICharacter target);
        void TakeDamage(int damage);

    }
}
