using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSleep", menuName = "Tanks/EffectLogic/EffectSleep", order = 0)]
public class EffectSleep : EffectLogic
{
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.SetStatus(TankStatusFlag.SLEEP);
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.ClearStatus(TankStatusFlag.SLEEP);
    }
}
