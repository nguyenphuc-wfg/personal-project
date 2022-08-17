using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectRoot", menuName = "Tanks/EffectLogic/EffectRoot", order = 0)]
public class EffectRoot : EffectLogic
{
    public override void OnStart(TankComponent tankComps, EffectData effectData)
    {
        ApplyEffect(tankComps, effectData);
    }
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.SetStatus(TankStatusFlag.ROOT);
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.ClearStatus(TankStatusFlag.ROOT);
    }
}