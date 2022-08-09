using UnityEngine;

public abstract class GunWeapon : Weapon
{
    [SerializeField] protected int _bulletsPerRound = 1;
    [SerializeField] protected Transform _fireTransform;
    [SerializeField] protected GameObject _bullet;
    protected int _currentFireBulletInround = 0;
    [SerializeField] private string _bulletName;
    protected override void Update()
    {
        if (IsFireInput() && IsAbleToFire())
            UseWeapon(transform.position + transform.forward);

        if (_isUsingWeapon)
            UpdateFiring();
        else _currentInterval -= Time.deltaTime;
    }

    protected virtual bool IsFireInput() => Input.GetKeyDown(KeyCode.Space) && _currentInterval <= 0;

    protected virtual bool IsAbleToFire() => !_isUsingWeapon;

    protected override void UseWeapon(Vector3 position)
    {
        _isUsingWeapon = true;
        transform.LookAt(position);
    }

    protected virtual void UpdateFiring()
    {
        FireOneBullet();
    }

    protected virtual void FireOneBullet()
    {
        FireOneBullet(_fireTransform.position, _fireTransform.rotation);
    }

    protected void FireOneBullet(Vector3 pos, Quaternion rotation)
    {
        GameObject bullet = ObjectPooling.Instance.GetObject(_bulletName, pos, rotation);
        bullet.GetComponent<Bullet>().InitStats(_owner);
        // Instantiate(_bullet,pos ,rotation );
        _currentFireBulletInround++;
        if (_currentFireBulletInround>= _bulletsPerRound)
            OnFinishFireRound();
    }

    protected virtual void OnFinishFireRound()
    {
        _isUsingWeapon = false;
        _currentFireBulletInround = 0;
        _currentInterval = _interval;
    }

    public override void ResetWeapon(){
        base.ResetWeapon();
        _currentFireBulletInround = 0;
        _currentInterval = 0;
    }

}

