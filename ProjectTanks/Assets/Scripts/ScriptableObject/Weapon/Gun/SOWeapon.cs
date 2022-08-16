using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SOWeapon", menuName = "Tanks/SOWeapon", order = 0)]
[System.Serializable]
public abstract class SOWeapon : ScriptableObject {
    public float _interval = 0;
    [HideInInspector] public float _currentInterval = 0;
    [HideInInspector] public bool _isUsingWeapon;
    [HideInInspector] public GameObject _owner;
    public abstract void OnUpdate();
    protected abstract void UseWeapon(Vector3 position);
    public virtual void ResetWeapon(){
        _isUsingWeapon = false;
    }
}