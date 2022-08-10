using UnityEngine;

public class EffectShield : Effect {
    [SerializeField] private float _percent;
    public float Percent {get{return _percent;} set {_percent = value;}}
    protected override void ApplyEffect()
    {
    }
    protected override void TimeOutEffect(){}
}