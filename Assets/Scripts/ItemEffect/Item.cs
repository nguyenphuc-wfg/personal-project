using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private EffectConfig _effect;
    private void OnTriggerEnter(Collider target)
    {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        tankComponent.TankEffect.AddEffect(_effect.CreateEffect());
        Destroy(gameObject);
    }
}
