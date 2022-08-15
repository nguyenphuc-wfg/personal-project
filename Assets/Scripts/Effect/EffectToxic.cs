using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectToxic", menuName = "Tanks/EffectLogic/EffectToxic", order = 0)]
public class EffectToxic : EffectLogic
{
    // [SerializeField] private EffectData _effect;
    public override void OnStart(TankComponent tankComps, EffectData effectData)
    {
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].EffectLogic is EffectImmune)
            {
                // toxicZone.RemoveEffect(_target, _effect);
                tankComps.TankEffect.RemoveEffect(effectData);
                return;
            }
        }
    }
    public override void OnUpdate(TankComponent tankComps, EffectData effectData)
    {
        base.OnUpdate(tankComps, effectData);
        effectData.SetCurrentInterval(effectData.CurrentInterval - Time.deltaTime);
        if (effectData.CurrentInterval <= 0)
        {
            effectData.SetCurrentInterval(effectData.Interval);
            ApplyEffect(tankComps, effectData);
        }
    }
    protected override void ApplyEffect(TankComponent tankComps, EffectData effectData)
    {
        List<EffectData> listEffect = tankComps.TankEffect.ListEffect;

        float damage;
        float shield = 0;

        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].EffectLogic is EffectShield)
                shield = Mathf.Max(shield, listEffect[i].Value);
            if (listEffect[i].EffectLogic is EffectSleep)
                tankComps.TankEffect.RemoveEffect(listEffect[i]);
        }
        damage = effectData.Value * (1 - shield / 100);
        tankComps.TankHealth.TakeDamage(damage);
    }
    public override void OnBeforeDestroy(TankComponent tankComps, EffectData effectData)
    {
    }
}