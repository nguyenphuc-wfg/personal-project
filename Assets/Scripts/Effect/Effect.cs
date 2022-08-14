using UnityEngine;
using System;

public abstract class Effect : MonoBehaviour {
    protected TankComponent _target;
    [SerializeField] protected Effect _effect;
    [SerializeField] protected float _lifeTime;
    [HideInInspector] public float _currentLifeTime;
    public virtual void SetUp(TankComponent target){
        _target = target;
    }
    public void OnUpdate() {
        if (_lifeTime == 0) return;
        TimeCountDown();
    }

    protected abstract void ApplyEffect();
    protected void TimeCountDown(){ 
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime  >= _lifeTime) {
            OnBeforeDestroy();
            _target.TankEffect.RemoveEffect(_effect);
        }
    }

    public virtual void SetCurrentTimeEffect(float lifeTime){
        _currentLifeTime = -lifeTime;
    }
    public abstract void OnBeforeDestroy();
}