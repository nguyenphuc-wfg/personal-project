using UnityEngine;

public class TankSpell : MonoBehaviour
{
    [SerializeField] private EffectConfig _spellEffectFirst;
    [SerializeField] private TankComponent _tankComponent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _tankComponent.TankEffect.AddEffect(_spellEffectFirst.CreateEffect());
        }
    }
}