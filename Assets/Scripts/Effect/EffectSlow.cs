using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectSlow : Effect {
    [SerializeField] private float _slowValue;
    [HideInInspector] public ToxicZone source;
    private void Start() {
        ApplyEffect();
    }
    protected override void ApplyEffect(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        float deltaSpeed = _slowValue;
        foreach (var item in listEffect){
            if (item.GetType() == typeof(EffectImmune)) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            }
        }
        _target.TankMovement._deltaSpeed = deltaSpeed;
    }
    protected override void TimeOutEffect()
    {
        _slowValue = 0f;
        ApplyEffect();
        source.RemoveEffect(_target, _effect);
    }
}