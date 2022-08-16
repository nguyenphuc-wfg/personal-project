using UnityEngine;
using UnityEngine.AI;

public class BulletFindWay : Bullet
{
    private Transform target;
    [SerializeField] private int _damage = 100;
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _radarRadius;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    public LayerMask _radarMask;
    [SerializeField] private EffectConfig[] _effects;
    private void Start()
    {
        _navMeshAgent.speed = _speed;
    }
    private void OnEnable()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }
    private void Update()
    {
        _rigidbody.AddTorque(transform.forward * _speed * 1000);
        FollowTargetWithRotation();
        Radaring();
    }
    private void OnDisable()
    {
        _rigidbody.isKinematic = true;
        target = null;
    }

    private void OnCollisionEnter(Collision target)
    {

        TankComponent tankComponent = target.gameObject.GetComponent<TankComponent>();

        if (!tankComponent) return;

        foreach (var effect in _effects)
        {
            tankComponent.TankEffect.AddEffect(effect.CreateEffect());
        }
        gameObject.SetActive(false);
    }
    private void Radaring()
    {
        if (target != null) return;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radarRadius, _radarMask);
        if (colliders.Length == 1) return;
        foreach (var collider in colliders)
        {
            if (collider.gameObject != _owner)
            {
                target = collider.gameObject.transform;
                return;
            }
        }
    }
    private void FollowTargetWithRotation()
    {
        if (target == null) return;
        _navMeshAgent.destination = target.position;
    }
}