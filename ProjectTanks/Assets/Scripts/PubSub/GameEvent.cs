using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Tanks/GameEvent", order = 0)]
public class GameEvent : ScriptableObject {
    private Action eventListeners = null;

    public void Excute(){
        eventListeners?.Invoke();
    }

    public void SubscribeListener(Action listener){
        eventListeners -= listener;
        eventListeners += listener;
    }

    public void UnSubscribeListener(Action listener){
        eventListeners -= listener;
    }
}