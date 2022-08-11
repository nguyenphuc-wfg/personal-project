using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectImmune : Effect {
    private void Start() {
        ApplyEffect();
    }
    protected override void ApplyEffect()
    {
        List<Effect> listEffect = _target.TankEffect.ListEffect;
        for (int i=0; i<listEffect.Count; i++){
            if (
                listEffect[i].GetType() == typeof(EffectToxic) ||
                listEffect[i].GetType() == typeof(EffectSlow) || 
                listEffect[i].GetType() == typeof(EffectStun)        
            ){
                _target.TankEffect.RemoveEffect(listEffect[i]);
                i--;
            }
              
        }
    }
    public override void OnBeforeDestroy()
    {
    }
}