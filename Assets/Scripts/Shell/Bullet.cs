using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    protected GameObject _owner;
    public virtual void InitStats(GameObject owner)
    {
        _owner = owner;
    }
}