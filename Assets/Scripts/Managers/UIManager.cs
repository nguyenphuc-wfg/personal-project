using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using Cysharp.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text m_MessageText;

    [SerializeField] private UIStats m_UIStats;

    public void ChangeMessage(){
        m_MessageText.text = m_UIStats.message;
    }
}
