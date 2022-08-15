using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_ExplosionParticle;
    [SerializeField] private AudioSource m_ExplosionAudio;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _maxDamage = 100f;
    public LayerMask _explosionMask;
    [SerializeField] private EffectConfig[] _effects;
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(-90f, 0, 0);
        m_ExplosionAudio.Play();
        m_ExplosionParticle.Play();
        Explosive();
        ObjectDestroy(m_ExplosionParticle.main.duration);
    }

    private void Explosive()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _explosionMask);

        foreach (var collider in colliders)
        {
            Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();

            if (!targetRigidbody) continue;
            targetRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

            TankComponent tankComponent = targetRigidbody.GetComponent<TankComponent>();
            if (!tankComponent) return;
            foreach (var effect in _effects)
            {
                tankComponent.TankEffect.AddEffect(effect.CreateEffect(CalculateDamage(collider.transform.position)));
            }
        }
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (_explosionRadius - explosionDistance) / _explosionRadius;

        float damage = relativeDistance * _maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
    private async UniTask ObjectDestroy(float time)
    {
        await UniTask.Delay((int)(time * 1000));
        gameObject.SetActive(false);
    }
}
