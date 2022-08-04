using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Tanks/GameEvent", order = 0)]
public class GameEvent : ScriptableObject {
    private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void Excute(){
        foreach (GameEventListener item in eventListeners){
            item.OnEventExcute();
        }
    }

    public void SubscribeListener(GameEventListener listener){
        if (!eventListeners.Contains(listener)){
            eventListeners.Add(listener);
        }
    }

    public void UnSubscribeListener(GameEventListener listener){
        if (eventListeners.Contains(listener)){
            eventListeners.Remove(listener);
        }
    }
}