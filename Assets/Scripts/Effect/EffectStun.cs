using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectStun : Effect {
    private void Start() {
        ApplyEffect();
    }
    protected override void ApplyEffect(){
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        foreach (var item in listEffect){
            if (item.GetType() == typeof(EffectImmune)) {
                _target.TankEffect.RemoveEffect(_effect);
                return;
            }
        }
        _target.OnStun();
    }
    protected override void TimeOutEffect(){
        Debug.Log("offstun");
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        foreach (var item in listEffect){
            if (item.GetType() == typeof(EffectStun))
                if (item != _effect)
                    return;
        }
        Debug.Log("offstun");
        _target.OffStun();
    }
}