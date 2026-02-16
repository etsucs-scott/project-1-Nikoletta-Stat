namespace AdventureGame.Core
{
    public interface ICharacter
    {
        int Health { get; }
        int BaseDamage { get; }
        void Attack(ICharacter target);
        void TakeDamage();

    }
}
