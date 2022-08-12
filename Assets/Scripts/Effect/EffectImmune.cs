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
            if (listEffect[i].gameObject.tag == "NegativeEffect"){
                _target.TankEffect.RemoveEffect(listEffect[i]);
                i--;
            }
              
        }
    }
    public override void OnBeforeDestroy()
    {
    }
}