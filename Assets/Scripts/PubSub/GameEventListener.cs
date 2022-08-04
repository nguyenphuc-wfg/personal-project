using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable() {
        Event.SubscribeListener(OnEventExcute);
    }

    private void OnDisable() {
        Event.UnSubscribeListener(OnEventExcute);
    }

    public void OnEventExcute(){
        Response?.Invoke();
    }
}