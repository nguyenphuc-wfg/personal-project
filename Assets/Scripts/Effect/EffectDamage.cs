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

        foreach(var item in listEffect){
            if (item.GetType() == typeof(EffectShield)){
                EffectShield effect = (EffectShield) item;
                shield = Mathf.Max(shield, effect.Percent);
                damage = _damage * (1 - shield/100);
            }
        }
        _target.TankHealth.TakeDamage(damage);
        _target.TankEffect.RemoveEffect(_effect);
        Destroy(gameObject);
    }
    protected override void TimeOutEffect(){}
}