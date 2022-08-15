using UnityEngine;
using System;
public class TankEvent : MonoBehaviour
{
    private Action<TankStatusFlag> eventListeners = null;

    public void Excute(TankStatusFlag flag)
    {
        eventListeners?.Invoke(flag);
    }
    public void SubscribeListener(Action<TankStatusFlag> listener)
    {
        eventListeners -= listener;
        eventListeners += listener;
    }
    public void UnSubscribeListener(Action<TankStatusFlag> listener)
    {
        eventListeners -= listener;
    }
}