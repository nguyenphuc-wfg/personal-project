using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _interval;
    protected float _currentInterval = 0;
    protected bool _isUsingWeapon;
    [SerializeField] protected GameObject _owner;

    protected abstract void Update();
    protected abstract void UseWeapon(Vector3 position);
    public virtual void ResetWeapon(){
        _isUsingWeapon = false;
    }
}


