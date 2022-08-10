using UnityEngine;

public class BulletToxic : Bullet {
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _toxicZone;
    private void OnEnable() {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnDisable() {
        _rigidbody.isKinematic = true;
    }   
    private void OnCollisionEnter(Collision target) {
        Vector3 pos = new Vector3(transform.position.x, 0.1f, transform.position.z);
        GameObject zone = ObjectPooling.Instance.GetObject("ToxicZone", pos, _toxicZone.transform.rotation);
        zone.GetComponent<ParticleSystem>().Play();
        gameObject.SetActive(false);
    }
}