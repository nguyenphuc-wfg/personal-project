using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectToxic : Effect {
    [SerializeField] private float _damageInterval;
    [SerializeField] private float _damage;
    private float _currentInterval = 0;
    [HideInInspector] public ToxicZone toxicZone;
    protected override void Update() {
        base.Update();
        _currentInterval += Time.deltaTime;
        if (_currentInterval >= _damageInterval){
            _currentInterval = 0;
            ApplyEffect();
        }
    }
    protected override void ApplyEffect(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        float damage = _damage;
        float shield = 0;
        foreach (var item in listEffect){
            if (item.GetType() == typeof(EffectImmune)) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            } 
            if (item.GetType() == typeof(EffectShield)) {
                EffectShield effect = (EffectShield) item;
                shield = Mathf.Max(shield,effect.Percent);
                damage = _damage * (1 - shield/100);
            }
            
        }
        _target.TankHealth.TakeDamage(damage);
    }
    protected override void TimeOutEffect(){
        toxicZone.RemoveEffect(_target, _effect);
    }
}