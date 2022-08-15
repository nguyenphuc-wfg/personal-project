using UnityEngine;

public abstract class GunWeapon : Weapon
{
    protected int _bulletsPerRound = 1;
    [HideInInspector] public Transform _fireTransform;
    [HideInInspector] protected GameObject _bullet;
    protected int _currentFireBulletInround = 0;
    [HideInInspector] public string _bulletName;
    public override void OnUpdate()
    {
        if (IsFireInput() && IsAbleToFire())
            UseWeapon(_owner.transform.position + _owner.transform.forward);

        if (_isUsingWeapon)
            UpdateFiring();
        else _currentInterval -= Time.deltaTime;
    }

    protected virtual bool IsFireInput() => Input.GetButtonDown($"Fire{_idPlayer}") && _currentInterval <= 0;

    protected virtual bool IsAbleToFire() => !_isUsingWeapon;

    protected override void UseWeapon(Vector3 position)
    {
        _isUsingWeapon = true;
        _owner.transform.LookAt(position);
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
        GameObject bullet = Pool.Instance.Get(_bulletName, pos, rotation);
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
    public override void SetUpData(DataWeapon data){
        base.SetUpData(data);
        if (!(data is DataGunWeapon dataGunWeapon)) 
            return;
        _bulletsPerRound = dataGunWeapon._bulletsPerRound;
    }

}

