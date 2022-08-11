using System;
using UnityEngine;

[Serializable]
public class TankManager
{
    public Color m_PlayerColor;            
    public Transform m_SpawnPoint;         
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;                     


    private TankMovement m_Movement;       
    private TankWeapon m_Shooting;
    private GameObject m_CanvasGameObject;

    private TankGroup m_TankGroup;
    private TankComponent m_TankComponent;

    public void Setup()
    {
        m_TankGroup = m_Instance.GetComponent<TankGroup>();
        m_TankComponent = m_Instance.GetComponent<TankComponent>();

        m_Movement = m_TankGroup.m_Movement;    
        m_Shooting = m_TankGroup.m_Shooting;
        m_CanvasGameObject = m_TankGroup.m_CanvasGameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
       // m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_Shooting.ResetWeapon();
        m_Movement.m_Rigidbody.isKinematic = true;

        m_CanvasGameObject.SetActive(false);
    }
    public void DisableShooting(){
        m_Shooting.enabled = false;
    }

    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }

    public void ClearTankEffect(){
        m_TankComponent.TankEffect.ClearEffect();
    }
    public void Reset()
    {

        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
