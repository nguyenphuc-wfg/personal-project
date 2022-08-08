using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_ExplosionParticle;
    [SerializeField] private AudioSource m_ExplosionAudio;  
    private void OnEnable() {
        m_ExplosionAudio.Play();
        ObjectDestroy(m_ExplosionParticle.main.duration);
    }

    private async UniTask ObjectDestroy(float time){
        await UniTask.Delay((int)(time*1000));
        gameObject.SetActive(false);
    }
}
