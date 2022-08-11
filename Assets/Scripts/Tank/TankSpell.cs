using UnityEngine;

public class TankSpell : MonoBehaviour {
    [SerializeField] private Effect _spellEffectFirst;
    [SerializeField] private TankComponent _tankComponent;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)){
            _tankComponent.TankEffect.AddEffect(_spellEffectFirst);
        }
    }
}