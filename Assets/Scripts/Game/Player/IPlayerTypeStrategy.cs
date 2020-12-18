namespace Game.Player
{
    public interface IPlayerTypeStrategy
    {
        void UseRangeAttack();
        void UseMeleeAttack();
        void UseAbility();
    }
}