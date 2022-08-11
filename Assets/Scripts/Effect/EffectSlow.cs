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
            if (listEffect[i])
                if (listEffect[i].GetType() == typeof(EffectImmune)) {
                    _target.TankEffect.RemoveEffect(_effect);
                    return;
                }
        }
        _target.TankMovement._deltaSpeed = deltaSpeed;
    }
    public override void OnBeforeDestroy(){
        _slowValue = 0f;
        _target.TankMovement._deltaSpeed = _slowValue;
        source.RemoveEffect(_target, _effect);
    }
}