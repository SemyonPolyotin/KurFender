namespace Game.Player
{
    public interface IPlayerTypeStrategy
    {
        void UseMeleeAttack();
        void UseRangeAttack();
        void UseAbility();
    }
}