using UnityEngine;

namespace Game.Player
{
    public class BarbarianStrategy : PlayerTypeStrategy<BarbarianData>
    {
        public BarbarianStrategy(BarbarianData playerTypeData) : base(playerTypeData)
        {
        }
        
        public override void UseAbility()
        {
            Debug.Log("Mighty axe");
        }
    }
}