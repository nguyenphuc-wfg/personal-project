using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Cysharp.Threading.Tasks;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;


    private string m_FireButton;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;
    private bool m_IsFiring;
    [SerializeField] private int numOfBullet;
    [SerializeField] private float speedShoot;
    private float timeCount;

    [SerializeField] private float bulletInterval = 1;
    private float currentBulletInterval = 1;
    private float currentFireInterval;
    private int currentFiredBullet = 0;
    private void OnEnable()
    {
        // m_CurrentLaunchForce = m_MinLaunchForce;
        // m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;
        currentBulletInterval = bulletInterval;
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        if (Input.GetButtonDown(m_FireButton) && !m_IsFiring && timeCount < 0)
            m_IsFiring = true;

        if (m_IsFiring)
            UpdateFire();
        else 
            timeCount -= Time.deltaTime;
    }

    private void UpdateFire()
    {
        currentBulletInterval -= Time.deltaTime;
        if (currentBulletInterval > 0)
            return;
        FireOneBullet();
    }

    private void FireOneBullet()
    {
        currentBulletInterval = bulletInterval;
        Fire();
        currentFiredBullet++;
        if (currentFiredBullet >= numOfBullet)
        {
            currentFiredBullet = 0;
            m_IsFiring = false;
            timeCount = currentFireInterval;
        }
    }

    private void Fire()
    {
        // Instantiate and launch the shell.

        // Get Pooling Bullet
        GameObject obj = ObjectPooling.Instance.GetObject("Bullet");
        obj.transform.position = m_FireTransform.position;
        obj.transform.rotation = m_FireTransform.rotation;

        Rigidbody shellInstance = obj.GetComponent<Rigidbody>();

        shellInstance.isKinematic = false;


        shellInstance.velocity = m_MaxLaunchForce * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // m_CurrentLaunchForce = m_MinLaunchForce;
    }
}