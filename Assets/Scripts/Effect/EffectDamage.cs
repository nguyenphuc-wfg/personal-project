using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectDamage : Effect {
    [SerializeField] private float _damage;
    private void Start() {
        ApplyEffect();
    }
    public void SetDamage(float damage){
        _damage = damage;
    }
    protected override void ApplyEffect(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;

        float damage = _damage;
        float shield = 0;

        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i] is EffectShield){
                EffectShield effect = (EffectShield) listEffect[i];
                shield = Mathf.Max(shield, effect.Percent);
                damage = _damage * (1 - shield/100);
            }
            if (listEffect[i] is EffectSleep){
                _target.TankEffect.RemoveEffect(listEffect[i]);
            }
        }
        _target.TankHealth.TakeDamage(damage);
        _target.TankEffect.RemoveEffect(_effect);
    }
    public override void OnBeforeDestroy()
    {
    }
}