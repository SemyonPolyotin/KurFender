using UnityEngine;

namespace Game.Player
{
    public class ArcherStrategy : PlayerTypeStrategy<ArcherData>
    {
        public ArcherStrategy(ArcherData playerTypeData) : base(playerTypeData)
        {
        }

        public override void UseAbility()
        {
            Debug.Log("Power shot");
        }
    }
}