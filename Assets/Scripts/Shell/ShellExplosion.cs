using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    private ParticleSystem m_ExplosionParticles;       
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              
    public Light m_Light;
    public Rigidbody m_Rigidbody;
    public CapsuleCollider m_BoxCollider;
    private CancellationTokenSource cts;
    private void OnEnable()
    {
        m_BoxCollider.enabled = true;
        
        ObjectDestroy(m_MaxLifeTime);
    }
    private void OnDisable() {
        cts?.Cancel();
    }
    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag != "Player") return;
        // Find all the tanks in an area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        
        for (int i=0; i< colliders.Length; i++) {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (!targetHealth){
                continue;
            }

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }
        m_Light.enabled = false;

        m_ExplosionParticles = ObjectPooling.Instance.GetObject("Explosion").GetComponent<ParticleSystem>();

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.Play();

        m_Rigidbody.isKinematic = true;
        m_BoxCollider.enabled = false;

        cts?.Cancel();
        ObjectDestroy(0f);

    }

    private async UniTask ObjectDestroy(float time){
        cts = new CancellationTokenSource();

        await UniTask.Delay((int)(time*1000), cancellationToken: cts.Token);

        cts = null;

        m_Rigidbody.isKinematic = false;
        gameObject.SetActive(false);
    }
    
    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
    
        float damage = relativeDistance * m_MaxDamage; 

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}