using UnityEngine;

public class BulletNormal : Bullet {
    [SerializeField] private int _damage = 100;
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private Effect _effectDamage;
    private void OnEnable() {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnDisable() {
        _rigidbody.isKinematic = true;
    }   

    private void OnCollisionEnter(Collision target) {
        TankComponent tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (tankComponent) {
            EffectDamage effect = (EffectDamage) tankComponent.TankEffect.AddEffect(_effectDamage);
            effect.SetDamage(_damage);
        }
          
        GameObject newExplosion = Pool.Instance.Get("Explosion", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}