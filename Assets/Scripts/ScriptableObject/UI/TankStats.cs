using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tank")]
public class TankStats : ScriptableObject
{
    [SerializeField] protected float m_Speed;
    [SerializeField] protected float m_TurnSpeed;
    
    public float M_Speed {get {return m_Speed;}}
    public float M_TurnSpeed {get {return m_TurnSpeed;}}
}
