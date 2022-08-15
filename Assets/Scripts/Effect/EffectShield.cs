using UnityEngine;

[CreateAssetMenu(fileName = "EffectShield", menuName = "Tanks/EffectLogic/EffectShield", order = 0)]
public class EffectShield : EffectLogic
{
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
    }
}