using UnityEngine;

public class BulletFindWay : Bullet {
    [SerializeField] private Transform target;
    [SerializeField] private int _damage = 100;
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _speed;
    [SerializeField] private float _radarRadius;
    public LayerMask _radarMask;

    private void OnEnable() {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }
    private void Update() {
        FollowTargetWithRotation();
        Radaring();
    }
    private void OnDisable() {
        _rigidbody.isKinematic = true;
        target = null;
    }

    private void OnCollisionEnter(Collision target){
        TankHealth targetHealth = target.gameObject.GetComponent<TankHealth>();

        if (targetHealth)
            targetHealth.TakeDamage(_damage);

        GameObject newExplosion = ObjectPooling.Instance.GetObject("Explosion", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    private void Radaring(){
        if (target != null) return;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radarRadius, _radarMask);
        if (colliders.Length == 1) return;
        foreach (var collider in colliders){
            if (collider.gameObject != _owner) {
                target = collider.gameObject.transform;
            }
        }
    }
    private void FollowTargetWithRotation()
    {
        if (target == null) return;
        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position) > 0)
        {
            transform.LookAt(target);
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _speed/2, ForceMode.Force);
        }
    }
}