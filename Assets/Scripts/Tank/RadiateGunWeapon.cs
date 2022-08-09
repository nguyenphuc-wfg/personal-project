using UnityEngine;

public class RadiateGunWeapon: GunWeapon {
    [SerializeField] private float _radiateAngle;
    //[SerializeField] private Transform fireTransform;
    protected override void UpdateFiring()
    {
        int startIndex = _bulletsPerRound % 2 == 0 ? 2 : 1;
        int endIndex = _bulletsPerRound % 2 == 0 ? _bulletsPerRound + 1 : _bulletsPerRound;
        for (int i = startIndex; i <= endIndex; i++ ){
            var pos = _fireTransform.position;
            var euler = _fireTransform.eulerAngles;
        
            if (_bulletsPerRound % 2 != 0)
                euler.y += _radiateAngle * (i % 2 == 0 ? -i/2 : i/2);
            else {
                if (i == 1 || i == 2) {
                    euler.y += i == 1 ? _radiateAngle/2 : -_radiateAngle/2;
                } else {
                    euler.y += (i % 2 == 0 ? _radiateAngle/2 : -_radiateAngle/2) + _radiateAngle * (i % 2 == 0 ? -i/2 : i/2);
                }
            }
            var rotation =  Quaternion.Euler(euler);
            FireOneBullet(pos, rotation);
            Debug.DrawLine(pos, pos + rotation * Vector3.forward * 10, Color.red, 1);
        }
    }
}