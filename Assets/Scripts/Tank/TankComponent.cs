using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;
    [SerializeField] private TankEffect tankEffect;
    [SerializeField] private TankWeapon tankWeapon;
    [SerializeField] private TankStatus tankStatus;
    [SerializeField] private TankWeaponControl tankWeaponControl;
    [SerializeField] private WeaponManager weaponManager;

    public GameObject m_CanvasGameObject;
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
    public TankEffect TankEffect {get {return tankEffect;}}
    public TankWeapon TankWeapon {get {return tankWeapon;}}
    public TankStatus TankStatus {get {return tankStatus;}}
    public TankWeaponControl TankWeaponControl {get {return tankWeaponControl;}}
    public WeaponManager WeaponManager {get {return weaponManager;}}
}