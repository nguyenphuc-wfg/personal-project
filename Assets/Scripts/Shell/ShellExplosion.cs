using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              
    public MeshRenderer m_MeshRenderer;
    public Light m_Light;
    public Rigidbody m_Rigidbody;
    public CapsuleCollider m_BoxCollider;
    private async void OnEnable()
    {
        m_BoxCollider.enabled = true;
        await ObjectDestroy(m_MaxLifeTime);
    }
    private async void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return;
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
        m_MeshRenderer.enabled = false;
        m_Light.enabled = false;
        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();
        m_Rigidbody.isKinematic = true;
        m_BoxCollider.enabled = false;
        await ObjectDestroy(m_ExplosionParticles.main.duration);
    
    }

    private async UniTask ObjectDestroy(float time){

        await UniTask.Delay((int)(time*1000));

        Debug.Log(!gameObject.activeSelf);
        m_MeshRenderer.enabled = true;
        m_Light.enabled = true;
        m_ExplosionParticles.transform.SetParent(this.gameObject.transform);
        m_ExplosionParticles.transform.localPosition = Vector3.zero;

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