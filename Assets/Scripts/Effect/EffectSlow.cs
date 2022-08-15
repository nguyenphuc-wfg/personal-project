using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectSlow", menuName = "Tanks/EffectLogic/EffectSlow", order = 0)]
public class EffectSlow : EffectLogic
{
    // [SerializeField] private float _slowValue;
    // [HideInInspector] public ToxicZone source;
    public override void OnStart(TankComponent tankComps, EffectData effectData)
    {
        ApplyEffect(tankComps, effectData);
    }
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        float deltaSpeed = effectData.Value;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].EffectLogic is EffectImmune)
            {
                tankComps.TankEffect.RemoveEffect(effectData);
                return;
            }
            if (listEffect[i].EffectLogic is EffectSlow)
                deltaSpeed = Mathf.Max(listEffect[i].Value, deltaSpeed);
        }
        tankComps.TankMovement._deltaSpeed = deltaSpeed;
    }
    public override void OnBeforeDestroy(TankComponent tankComps, EffectData effectData)
    {
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        float deltaSpeed = 0;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].EffectLogic is EffectSlow && listEffect[i] != effectData)
            {
                deltaSpeed = Mathf.Max(effectData.Value, deltaSpeed);
            }
        }
        tankComps.TankMovement._deltaSpeed = deltaSpeed;
        // source.RemoveEffect(_target, _effect);
    }
}