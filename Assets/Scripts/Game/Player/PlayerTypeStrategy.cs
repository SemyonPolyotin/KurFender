namespace Game.Player
{
    public abstract class PlayerTypeStrategy<T> : IPlayerTypeStrategy where T : PlayerTypeDataBase
    {
        protected readonly T PlayerTypeData;

        protected PlayerTypeStrategy(T playerTypeData)
        {
            PlayerTypeData = playerTypeData;
        }

        public virtual void UseRangeAttack()
        {
        }

        public virtual void UseMeleeAttack()
        {
        }

        public virtual void UseAbility()
        {
        }
    }
}