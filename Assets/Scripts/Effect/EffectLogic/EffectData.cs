using UnityEngine;
using System;

public class EffectData
{
    protected GameObject _vfxPrefab;
    protected EffectType _type;
    protected EffectAddType _addType;
    protected EffectLogic _effectLogic;
    protected EffectPropsType _effectPropsType;
    protected float _lifeTime;
    protected float _currentLifeTime;
    protected float _interval;
    protected float _currentInterval = 0;
    protected float _value;
    public float TimeRemaining => _currentLifeTime;
    public float CurrentLifeTime => _currentLifeTime;
    public float Value => _value;
    public float Interval => _interval;
    public float CurrentInterval => _currentInterval;
    public GameObject VfxPrefab => _vfxPrefab;
    public GameObject VfxInstance;
    public EffectType Type => _type;
    public EffectAddType AddType => _addType;
    public EffectLogic EffectLogic => _effectLogic;
    public EffectPropsType EffectPropsType => _effectPropsType;
    public EffectData(EffectLogic logic, float lifeTime, float interval, float value, EffectType type, EffectAddType addType, EffectPropsType effectPropsType, GameObject vfx)
    {
        _effectLogic = logic;
        _lifeTime = lifeTime;
        _currentLifeTime = lifeTime;
        _interval = interval;
        _currentInterval = interval;
        _value = value;
        _type = type;
        _addType = addType;
        _effectPropsType = effectPropsType;
        _vfxPrefab = vfx;
    }
    public void OnStart(TankComponent tankComps)
    {
        _effectLogic.OnStart(tankComps, this);
    }
    public void OnUpdate(TankComponent tankComps)
    {
        _effectLogic.OnUpdate(tankComps, this);
    }
    public void SetCurrentTimeEffect(float time)
    {
        _currentLifeTime = time;
    }
    public void ResetCurrentLifeTime()
    {
        _currentLifeTime = _lifeTime;
    }
    public void OnRemoveEffect(TankComponent tankComps)
    {
        _effectLogic.OnRemoveEffect(tankComps, this);
    }
    public void SetCurrentInterval(float interval)
    {
        _currentInterval = interval;
    }
    public void SetVFX(GameObject vfx)
    {
        VfxInstance = vfx;
    }
}

public enum EffectType
{
    NONE = 0,
    STUN = 1,
    ROOT = 2,
    SLEEP = 3,
    POSSION = 4,
}

public enum EffectAddType
{
    NONE = 0,
    REPLACE_OVER = 1,
    REPLACE = 2,
    CUMULATIVE = 3
}

public enum EffectPropsType
{
    NEUTRAL = 0,
    POSITIVE = 1,
    NEGATIVE = 2,
}