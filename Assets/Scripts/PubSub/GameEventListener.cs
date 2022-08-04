using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable() {
        Event.SubscribeListener(this);
    }

    private void OnDisable() {
        Event.UnSubscribeListener(this);
    }

    public void OnEventExcute(){
        Response.Invoke();
    }
}