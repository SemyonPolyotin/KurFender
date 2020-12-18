using UnityEngine;

namespace Game.Player
{
    public class WizardStrategy : PlayerTypeStrategy<WizardData>
    {
        public WizardStrategy(WizardData playerTypeData) : base(playerTypeData)
        {
        }
        
        public override void UseAbility()
        {
            Debug.Log("Thunder strike");
        }
    }
}