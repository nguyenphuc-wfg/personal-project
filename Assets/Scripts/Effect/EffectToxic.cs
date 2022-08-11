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
        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i].GetType() == typeof(EffectImmune)) {
                 toxicZone.RemoveEffect(_target, _effect);
                _target.TankEffect.RemoveEffect(_effect);
                return;
            } 
            if (listEffect[i].GetType() == typeof(EffectShield)) {
                EffectShield effect = (EffectShield) listEffect[i];
                shield = Mathf.Max(shield,effect.Percent);
                damage = _damage * (1 - shield/100);
            }
            
        }
        _target.TankHealth.TakeDamage(damage);
    }
    public override void OnBeforeDestroy(){
        if (toxicZone)
            toxicZone.RemoveEffect(_target, _effect);
    }
}