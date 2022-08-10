using UnityEngine;

public class BulletDynamite : Bullet {
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private Effect _effectStun;
    
    private void OnEnable() {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnDisable() {
        _rigidbody.isKinematic = true;
    }   

    private void OnCollisionEnter(Collision target) {

        if (!target.gameObject.CompareTag("Player")) return;

        GameObject newExplosion = ObjectPooling.Instance.GetObject("Explosion", transform.position, Quaternion.identity);
        
        TankComponent tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (tankComponent){
            tankComponent.TankEffect.AddEffect(_effectStun);
        }
        gameObject.SetActive(false);
    }
}