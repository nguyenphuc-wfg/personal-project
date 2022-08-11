using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectStun : Effect {
    private void Start() {
        ApplyEffect();
    }
    protected override void ApplyEffect(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        for (int i=0 ; i<listEffect.Count; i++){
            if (listEffect[i].GetType() == typeof(EffectImmune)) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            }
        }
        _target.OnStun();
    }
    public override void OnBeforeDestroy(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        for (int i=0; i<listEffect.Count; i++){
            if (listEffect[i].GetType() == typeof(EffectStun))
                if (listEffect[i] != _effect)
                    return;
        }
        _target.OffStun();
    }
}