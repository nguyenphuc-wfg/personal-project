using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectSlow", menuName = "Tanks/EffectLogic/EffectSlow", order = 0)]
public class EffectSlow : EffectLogic
{
    public override void OnStart(TankComponent tankComps, EffectData effectData)
    {
        ApplyEffect(tankComps, effectData);
    }

    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        // List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        // float deltaSpeed = effectData.Value;
        // for (int i = 0; i < listEffect.Count; i++)
        // {
        //     if (listEffect[i].EffectLogic is EffectImmune)
        //     {
        //         tankComps.TankEffect.RemoveEffect(effectData);
        //         return;
        //     }
        //     if (listEffect[i].EffectLogic is EffectSlow)
        //         deltaSpeed += listEffect[i].Value;
        // }
        tankComps.TankMovement._percentSpeed += effectData.Value;
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
        // List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        // float deltaSpeed = 0;
        // for (int i = 0; i < listEffect.Count; i++)
        // {
        //     if (listEffect[i].EffectLogic is EffectSlow && listEffect[i] != effectData)
        //     {
        //         deltaSpeed = Mathf.Max(effectData.Value, deltaSpeed);
        //     }
        // }
        tankComps.TankMovement._percentSpeed -= effectData.Value;
    }
}