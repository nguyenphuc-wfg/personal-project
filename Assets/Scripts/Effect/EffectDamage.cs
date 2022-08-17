using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectDamage", menuName = "Tanks/EffectLogic/EffectDamage", order = 0)]
public class EffectDamage : EffectLogic
{
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
        damage = effectData.Value * (1 - Mathf.Min(shield, 100) / 100);
        tankComps.TankHealth.TakeDamage(damage);
        tankComps.TankEffect.RemoveEffect(effectData);
    }
    public override void OnRemoveEffect(TankComponent tankComps, EffectData effectData)
    {
    }
}