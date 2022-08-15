using UnityEngine;

public class BulletNormal : Bullet
{
    [SerializeField] private Light _light;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private EffectConfig[] _effects;
    private void OnEnable()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnDisable()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision target)
    {
        TankComponent tankComponent = target.gameObject.GetComponent<TankComponent>();
        if (tankComponent)
        {
            foreach (var effect in _effects)
            {
                tankComponent.TankEffect.AddEffect(effect.CreateEffect());
            }
        }

        Pool.Instance.Get("Explosion", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}