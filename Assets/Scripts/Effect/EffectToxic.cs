using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectToxic : Effect {
    [SerializeField] private float _damageInterval;
    [SerializeField] private float _damage;
    private float _currentInterval = 0;
    [HideInInspector] public ToxicZone toxicZone;
    [SerializeField] private Effect _effectDamage;
    private void Start() {
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i] is EffectImmune) {
                 toxicZone.RemoveEffect(_target, _effect);
                _target.TankEffect.RemoveEffect(_effect);
                return;
            } 
        }
    }
    protected void Update() {
        // base.Update();
        _currentInterval += Time.deltaTime;
        if (_currentInterval >= _damageInterval){
            _currentInterval = 0;
            ApplyEffect();
        }
    }
    protected override void ApplyEffect(){
        EffectDamage effect = (EffectDamage) _target.TankEffect.AddEffect(_effectDamage);
        effect.SetDamage(_damage);
    }
    public override void OnBeforeDestroy(){
        if (toxicZone)
            toxicZone.RemoveEffect(_target, _effect);
    }
}