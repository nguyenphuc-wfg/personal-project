using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZone : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private Effect _effectToxic, _effectSlow;
    [SerializeField] private ToxicZone _zone;
    private Dictionary<TankComponent, Effect> _listEffectToxic = new Dictionary<TankComponent, Effect>();
    private Dictionary<TankComponent, Effect> _listEffectSlow = new Dictionary<TankComponent, Effect>();
    private float _currentLifeTime = 0f;
    private void OnEnable() {
        _currentLifeTime = 0;
        _listEffectToxic.Clear();
    }
    private void Update() {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= _lifeTime) {
            TimeOutZone();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider target) {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        if (!_listEffectToxic.ContainsKey(tankComponent)){
            Effect effect = tankComponent.TankEffect.AddEffect(_effectToxic);
            EffectToxic effectToxic = (EffectToxic) effect;
            effectToxic.toxicZone = _zone;
            _listEffectToxic.Add(tankComponent, effectToxic);
            effect.SetCurrentTimeEffect(_lifeTime); 
        }  
        if (!_listEffectSlow.ContainsKey(tankComponent)){
            Effect effect = tankComponent.TankEffect.AddEffect(_effectSlow);
            EffectSlow effectSlow = (EffectSlow) effect;
            effectSlow.source = _zone;
            _listEffectSlow.Add(tankComponent, effect);
            effect.SetCurrentTimeEffect(_lifeTime); 
        }
        _listEffectToxic[tankComponent].SetCurrentTimeEffect(_lifeTime);
        _listEffectSlow[tankComponent].SetCurrentTimeEffect(_lifeTime);
    }

    private void OnTriggerExit(Collider target) {
        var tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (!tankComponent) return;
        _listEffectToxic[tankComponent].SetCurrentTimeEffect(0);
        _listEffectSlow[tankComponent].SetCurrentTimeEffect(0);
    }
    private void TimeOutZone(){
        foreach (var item in _listEffectToxic){
            item.Value.SetCurrentTimeEffect(0);
        }
         foreach (var item in _listEffectSlow){
            item.Value.SetCurrentTimeEffect(0);
        }
    }
    public void RemoveEffect(TankComponent target, Effect effect){
        if (effect.GetType() == typeof(EffectSlow)){
            _listEffectSlow.Remove(target);
        }
        if (effect.GetType() == typeof(EffectToxic)){
            _listEffectToxic.Remove(target);
        }
    }
}
