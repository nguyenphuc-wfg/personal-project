using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSleep", menuName = "Tanks/EffectLogic/EffectSleep", order = 0)]
public class EffectSleep : EffectLogic
{
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].EffectLogic is EffectImmune)
            {
                tankComps.TankEffect.RemoveEffect(effectData);
                return;
            }
        }
        tankComps.TankStatus.OnSleep();
    }
    public override void OnBeforeDestroy(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.OffSleep();
    }
}
