using UnityEngine;

[CreateAssetMenu(fileName = "SOGunWeapon", menuName = "Tanks/SOGunWeapon", order = 0)]
public class SOGunWeapon : SOWeapon {
    public int _bulletsPerRound = 1;
    [HideInInspector] public Transform _fireTransform;
    public string _bulletName;
    private int _currentFireBulletInround = 0;

    public override void OnUpdate(){
        if (IsFireInput() && IsAbleToFire())
            UseWeapon(_owner.transform.position + _owner.transform.forward);  
        if (_isUsingWeapon)
            UpdateFiring();
        else _currentInterval -= Time.deltaTime;
    }   
    public bool IsFireInput() => Input.GetKeyDown(KeyCode.Space) && _currentInterval <= 0;

    public bool IsAbleToFire() => !_isUsingWeapon;

    protected override void UseWeapon(Vector3 position)
    {
        _isUsingWeapon = true;
        _owner.transform.LookAt(position);
    }
    protected virtual void UpdateFiring(){
        FireOneBullet();
    }
    public virtual void FireOneBullet(){
        FireOneBullet(_fireTransform.position, _fireTransform.rotation);
    }
    public void FireOneBullet(Vector3 pos, Quaternion rotation){
        GameObject bullet = ObjectPooling.Instance.GetObject(_bulletName, pos, rotation);
        bullet.GetComponent<Bullet>().InitStats(_owner);
        _currentFireBulletInround++;
        if (_currentFireBulletInround>= _bulletsPerRound)
            OnFinishFireRound();
    }
    protected virtual void OnFinishFireRound(){
        _isUsingWeapon = false;
        _currentFireBulletInround = 0;
        _currentInterval = _interval;
    }
    public override void ResetWeapon(){
        _currentFireBulletInround = 0;
        _currentInterval = 0;
    }
}