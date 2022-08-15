using UnityEngine;
using System;
public class TankEvent : MonoBehaviour
{
    private Action eventListeners = null;

    public void Excute()
    {
        eventListeners?.Invoke();
    }
    public void SubscribeListener(Action listener)
    {
        eventListeners -= listener;
        eventListeners += listener;
    }
    public void UnSubscribeListener(Action listener)
    {
        eventListeners -= listener;
    }
}