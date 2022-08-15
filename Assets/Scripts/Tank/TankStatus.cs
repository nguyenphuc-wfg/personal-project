using UnityEngine;
using System;
using UnityEngine.Events;

public class TankStatus : MonoBehaviour
{
    [SerializeField] private TankComponent _tankComponent;
    public TankComponent TankComponent { get { return _tankComponent; } }

    public bool isRoot;
    public bool isStun;
    public bool isTimeStop;
    public bool isSleep;
    public EffectType _effectType;
    public UnityEvent _event;
    public void OnStun()
    {
        isStun = true;
        _event.Invoke();
    }
    public void OffStun()
    {
        isStun = false;
        _event.Invoke();
    }
    public void OnRoot()
    {
        isRoot = true;
        _event.Invoke();
    }
    public void OffRoot()
    {
        isRoot = false;
        _event.Invoke();
    }
    public void OnSleep()
    {
        isSleep = true;
        _event.Invoke();
    }
    public void OffSleep()
    {
        isSleep = false;
        _event.Invoke();
    }
}