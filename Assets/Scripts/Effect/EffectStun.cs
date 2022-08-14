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
            if (listEffect[i] is EffectImmune) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            }
            if (listEffect[i] is EffectStun && listEffect[i] != _effect){
                if (listEffect[i]._currentLifeTime > _lifeTime)
                    _target.TankEffect.RemoveEffect(_effect);
                else 
                    _target.TankEffect.RemoveEffect(listEffect[i]);
            }
        }
        _target.TankStatus.OnStun();
    }
    public override void OnBeforeDestroy(){
        _target.TankStatus.OffStun();
    }
    
}