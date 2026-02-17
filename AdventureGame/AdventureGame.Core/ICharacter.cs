namespace AdventureGame.Core
{
    // ICharacter interface lists the required attributes of ICharacters like player and monster.
    public interface ICharacter
    {
        int Health { get; }
        int BaseDamage { get; }
        int damage { get; }
        void Attack(ICharacter target);
        void TakeDamage(int damage);

    }
}
