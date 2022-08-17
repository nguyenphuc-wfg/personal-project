using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectStun", menuName = "Tanks/EffectLogic/EffectStun", order = 0)]
public class EffectStun : EffectLogic
{
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.SetStatus(TankStatusFlag.STUN);
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.ClearStatus(TankStatusFlag.STUN);
    }

}