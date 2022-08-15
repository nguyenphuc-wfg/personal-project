using UnityEngine;
using System;

public abstract class EffectLogic : ScriptableObject
{
    public virtual void OnStart(TankComponent tankComps, EffectData effectData)
    {
        ApplyEffect(tankComps, effectData);
    }
    public virtual void OnUpdate(TankComponent tankComps, EffectData effectData)
    {
        TimeCountDown(tankComps, effectData);
    }

    protected abstract void ApplyEffect(TankComponent tankComps, EffectData effectData);

    protected void TimeCountDown(TankComponent tankComps, EffectData effectData)
    {
        effectData.SetCurrentTimeEffect(effectData.CurrentLifeTime - Time.deltaTime);
        if (effectData.CurrentLifeTime <= 0)
        {
            OnBeforeDestroy(tankComps, effectData);
            tankComps.TankEffect.RemoveEffect(effectData);
        }
    }
    public abstract void OnBeforeDestroy(TankComponent tankComps, EffectData effectData);
}