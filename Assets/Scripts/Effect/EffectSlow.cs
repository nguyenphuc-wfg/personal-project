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
        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i] is EffectImmune) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            }
            if (listEffect[i] is EffectSlow effectSlow){
                deltaSpeed = Mathf.Max(effectSlow._slowValue, deltaSpeed);
            }
        }
        _target.TankMovement._deltaSpeed = deltaSpeed;
    }
    public override void OnBeforeDestroy(){
        _slowValue = 0f;
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        float deltaSpeed = _slowValue;
        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i] is EffectSlow effectSlow && listEffect[i] != _effect){
                deltaSpeed = Mathf.Max(effectSlow._slowValue, deltaSpeed);
            }
        }
        _target.TankMovement._deltaSpeed = deltaSpeed;
        source.RemoveEffect(_target, _effect);
    }
}