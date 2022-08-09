using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _interval;
    protected float _currentInterval = 0;
    protected bool _isUsingWeapon;
    [SerializeField] protected GameObject _owner;

    //private void Start()
    // {
    //     currentBulletInterval = bulletInterval;
    //     m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    // }
    protected abstract void Update();

    protected abstract void UseWeapon(Vector3 position);

    // private void UpdateFire()
    // {
    //     currentBulletInterval -= Time.deltaTime;
    //     if (currentBulletInterval > 0)
    //         return;
    //     FireOneBullet();
    // }

    // private void FireOneBullet()
    // {
    //     currentBulletInterval = bulletInterval;
    //     Fire();
    //     currentFiredBullet++;
    //     if (currentFiredBullet >= numOfBullet)
    //     {
    //         currentFiredBullet = 0;
    //         m_IsFiring = false;
    //         timeCount = currentFireInterval;
    //     }
    // }

    // private void Fire()
    // {

    //     GameObject obj = ObjectPooling.Instance.GetObject("Bullet");
    //     obj.transform.position = m_FireTransform.position;
    //     obj.transform.rotation = m_FireTransform.rotation;
    //     Rigidbody shellInstance = obj.GetComponent<Rigidbody>();
    //     shellInstance.isKinematic = false;
    //     shellInstance.velocity = m_MaxLaunchForce * m_FireTransform.forward;
    // }
    public virtual void ResetWeapon(){
        _isUsingWeapon = false;
    }
}


