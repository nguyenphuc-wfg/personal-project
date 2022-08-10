using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : MonoBehaviour
{
    [SerializeField] private Effect _shieldEffect;
    [SerializeField] private float _percent;
    private void OnTriggerEnter(Collider target) {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        EffectShield effect = (EffectShield) tankComponent.TankEffect.AddEffect(_shieldEffect);
        effect.Percent = _percent;
        Destroy(gameObject);
    }
}
