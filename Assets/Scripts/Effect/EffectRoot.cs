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
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if ((listEffect[i].EffectLogic is EffectImmune))
            {
                tankComps.TankEffect.RemoveEffect(effectData);
                return;
            }
        }
        tankComps.TankStatus.OnRoot();
    }
    public override void OnBeforeDestroy(TankComponent tankComps, EffectData effectData)
    {
        tankComps.TankStatus.OffRoot();
    }
}