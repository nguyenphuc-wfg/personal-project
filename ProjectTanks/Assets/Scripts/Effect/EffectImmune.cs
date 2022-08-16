using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectImmune", menuName = "Tanks/EffectLogic/EffectImmune", order = 0)]
public class EffectImmune : EffectLogic
{
    public override void OnStart(TankComponent tankComps, EffectData effectData)
    {
        ApplyEffect(tankComps, effectData);
    }
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankEffect.RemoveEffectTypeProps(EffectPropsType.NEGATIVE);
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
    }
}