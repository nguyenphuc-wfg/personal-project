using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public int m_NumRoundsToWin = 5;                 
    public CameraControl m_CameraControl;   
    public GameObject m_TankPrefab;         
    public TankManager[] m_Tanks;         

    public static int m_StartDelay = 3000;         
    public static int m_EndDelay = 3000; 

    private int m_RoundNumber;                   
    private TankManager m_RoundWinner;
    private TankManager m_GameWinner;
    
    const float k_MaxDepenetrationVelocity = float.PositiveInfinity;

    [SerializeField] private UIStats m_UIStats;
    public UnityEvent ChangeUIEvent;
    public GameEvent Event;

    private void Start()
    {
        // This line fixes a change to the physics engine.
        Physics.defaultMaxDepenetrationVelocity = k_MaxDepenetrationVelocity;

        SpawnAllTanks();
        SetCameraTargets();

        GameLoop();
    }
    private void OnEnable(){
        Event.SubscribeListener(EndingGame);
    }
    private void OnDisable(){
        Event.UnSubscribeListener(EndingGame);
    }
    private void SpawnAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }

    public async void GameLoop(){
        await StartMatch();
        await PlayMatch();
    }
    
    private async UniTask StartMatch(){
        
        RoundStarting();

        await UniTask.Delay(m_StartDelay);

    }
    
    private async UniTask PlayMatch(){

        RoundPlaying();
    }
    public void EndingGame(){
        EndMatch();
    }
    private async UniTask EndMatch(){
        
        await UniTask.WaitUntil(() => OneTankLeft());
        
        RoundEnding();
       
        await UniTask.Delay(m_EndDelay);

        if (IsMatchEnding()){
            SceneManager.LoadScene(0);
        } else {
            GameLoop();
        }
        
    }

    public void RoundStarting()
    {
        
        ResetAllTanks();
        DisableTankControl();

        m_CameraControl.SetStartPositionAndSize();
        m_RoundNumber++;
        m_UIStats.message = $"ROUND {m_RoundNumber}";
        ChangeUIEvent.Invoke();

    }


    public void RoundPlaying()
    {
        EnableTankControl();

        m_UIStats.message =  string.Empty;
        ChangeUIEvent.Invoke();
    }


    public void RoundEnding()
    {
        ClearTankEffect();
        DisableTankControl();
        ObjectPooling.Instance.ReturnAllPool();
        m_RoundWinner = null;

        m_RoundWinner = GetRoundWinner();

        if (m_RoundWinner != null) {
            m_RoundWinner.m_Wins++;
        }

        m_GameWinner = GetGameWinner();

        string message = EndMessage();
        m_UIStats.message = message;
        ChangeUIEvent.Invoke();

    }
    public bool IsMatchEnding(){
        return (m_GameWinner != null);
    }
    // public void TankLeft(){
    //     if (OneTankLeft()){
    //         // UIManager.Instance.EndMatchLoop();
    //     }
    // }
    public bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }


    private TankManager GetRoundWinner()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                return m_Tanks[i];
        }

        return null;
    }


    private TankManager GetGameWinner()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        return null;
    }


    private string EndMessage()
    {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }


    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }

    private void ClearTankEffect(){
        for (int i=0; i< m_Tanks.Length; i++){
            m_Tanks[i].ClearTankEffect();
        }
    }
}