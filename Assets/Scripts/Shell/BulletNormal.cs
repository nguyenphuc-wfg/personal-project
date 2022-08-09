using UnityEngine;

public class BulletNormal : Bullet {
    [SerializeField] private int _damage = 100;
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void OnEnable() {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnDisable() {
        _rigidbody.isKinematic = true;
    }   

    private void OnCollisionEnter(Collision target) {
    
        TankHealth targetHealth = target.gameObject.GetComponent<TankHealth>();
        if (targetHealth) 
            targetHealth.TakeDamage(_damage);
        GameObject newExplosion = ObjectPooling.Instance.GetObject("Explosion", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}