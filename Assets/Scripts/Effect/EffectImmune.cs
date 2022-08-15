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
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        for (int i = listEffect.Count - 1; i >= 0; i--)
        {
            if (listEffect[i].EffectPropsType == EffectPropsType.NEGATIVE)
                tankComps.TankEffect.RemoveEffect(listEffect[i]);
        }
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
    }
}