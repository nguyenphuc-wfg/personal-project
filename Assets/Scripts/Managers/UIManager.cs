using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using Cysharp.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    public GameEvent Event;
    [SerializeField] private Text m_MessageText;

    [SerializeField] private UIStats m_UIStats;
    private void OnEnable() {
        Event.SubscribeListener(ChangeMessage);
    }

    private void OnDisable() {
        Event.UnSubscribeListener(ChangeMessage);
    }
    public void ChangeMessage(){
        m_MessageText.text = m_UIStats.message;
    }
}
