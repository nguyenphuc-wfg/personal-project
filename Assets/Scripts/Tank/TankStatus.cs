using UnityEngine;
using System;
using UnityEngine.Events;

public class TankStatus : MonoBehaviour
{
    [SerializeField] private TankComponent _tankComponent;
    public TankComponent TankComponent { get { return _tankComponent; } }
    public UnityEvent<TankStatusFlag> _event;
    public TankStatusFlag flag;

    public void SetStatus(TankStatusFlag status)
    {
        flag = flag.SetFlag(status);
        _event.Invoke(flag);
    }
    public void ClearStatus(TankStatusFlag status)
    {
        flag = flag.ClearFlag(status);
        _event.Invoke(flag);
    }
}
[System.Flags]
public enum TankStatusFlag : int
{
    SLEEP = 1 << 0,
    STUN = 1 << 1,
    ROOT = 1 << 2,
}

public static class TankStatusFlagExtention
{
    public static TankStatusFlag SetFlag(this TankStatusFlag current, TankStatusFlag flag)
    {
        return current | flag;
    }
    public static bool Hasflag(this TankStatusFlag current, TankStatusFlag flag)
    {
        return (current & flag) == current;
    }
    public static TankStatusFlag ClearFlag(this TankStatusFlag current, TankStatusFlag flag)
    {
        return current & ~flag;
    }
}