using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSleep : MonoBehaviour
{
    [SerializeField] private Effect _effectSleep;
    private void OnTriggerEnter(Collider target) {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        tankComponent.TankEffect.AddEffect(_effectSleep);
        Destroy(gameObject);
    }
}
