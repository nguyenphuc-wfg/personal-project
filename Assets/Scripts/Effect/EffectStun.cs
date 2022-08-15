using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectStun", menuName = "Tanks/EffectLogic/EffectStun", order = 0)]
public class EffectStun : EffectLogic
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
        tankComps.TankStatus.OnStun();
    }
    public override void OnBeforeDestroy(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.OffStun();
    }

}