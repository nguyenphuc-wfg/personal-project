using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [SerializeField] protected float _interval;
    protected float _currentInterval = 0;
    protected bool _isUsingWeapon;
    [HideInInspector] public GameObject _owner;
    public int _idPlayer;

    public abstract void OnUpdate();
    protected abstract void UseWeapon(Vector3 position);
    public virtual void ResetWeapon(){
        _isUsingWeapon = false;
    }
}


