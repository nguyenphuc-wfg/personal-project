using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZone : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private EffectConfig[] _effects;
    [SerializeField] private ToxicZone _zone;
    private List<KeyValuePair<TankComponent, EffectData>> _listEffect = new List<KeyValuePair<TankComponent, EffectData>>();
    private float _currentLifeTime = 0f;
    private void OnEnable()
    {
        _currentLifeTime = 0;
        _listEffect.Clear();
    }
    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= _lifeTime)
        {
            TimeOutZone();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider target)
    {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        TriggerTarget(tankComponent);
    }
    private void OnTriggerStay(Collider target)
    {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        TriggerTarget(tankComponent);
    }
    private void TriggerTarget(TankComponent tankComponent)
    {
        bool isConstain = false;
        for (int i = 0; i < _listEffect.Count; i++)
        {
            if (_listEffect[i].Key == tankComponent)
            {
                isConstain = true;
                _listEffect[i].Value.SetCurrentTimeEffect(_lifeTime + 1);
            }
        }
        if (!isConstain)
        {
            foreach (var effect in _effects)
            {
                EffectData effectData = effect.CreateEffect();
                tankComponent.TankEffect.AddEffect(effectData);
                _listEffect.Add(new KeyValuePair<TankComponent, EffectData>(tankComponent, effectData));
                effectData.SetCurrentTimeEffect(_lifeTime + 1);
            }
        }
    }
    private void OnTriggerExit(Collider target)
    {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        for (int i = 0; i < _listEffect.Count; i++)
        {
            if (_listEffect[i].Key == tankComponent)
            {
                _listEffect[i].Value.ResetCurrentLifeTime();
            }
        }
    }
    private void TimeOutZone()
    {
        foreach (var item in _listEffect)
        {
            if (item.Value == null) continue;
            item.Value.ResetCurrentLifeTime();
        }
    }
}
