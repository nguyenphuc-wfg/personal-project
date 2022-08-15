using UnityEngine;
using System;

[Serializable]
public class EffectConfig
{
    [SerializeField] protected float _lifeTime;
    [SerializeField] protected float _interval;
    [SerializeField] protected float _value;
    [SerializeField] protected EffectType _type;
    [SerializeField] protected EffectAddType _addType;
    [SerializeField] protected EffectLogic _effectLogic;
    [SerializeField] protected EffectPropsType _effectPropsType;
    [SerializeField] protected GameObject _vfx;
    public EffectData CreateEffect()
    {
        return new EffectData(_effectLogic, _lifeTime, _interval, _value, _type, _addType, _effectPropsType, _vfx);
    }
    public EffectData CreateEffect(float value)
    {
        return new EffectData(_effectLogic, _lifeTime, _interval, value, _type, _addType, _effectPropsType, _vfx);
    }
}