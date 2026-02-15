namespace AdventureGame.Core
{
    public interface ICharacter
    {
        int Health { get; }
        int BaseDamage { get; }
        char Symbol { get; }
        void Attack(ICharacter target);
        void TakeDamage();

    }
}
