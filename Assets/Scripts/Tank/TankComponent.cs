using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;
    [SerializeField] private TankEffect tankEffect;
    [SerializeField] private TankWeapon tankWeapon;
    [SerializeField] private TankStatus tankStatus;
    [SerializeField] private TankWeapon2 tankWeapon2;
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
    public TankEffect TankEffect {get {return tankEffect;}}
    public TankWeapon TankWeapon {get {return tankWeapon;}}
    public TankStatus TankStatus {get {return tankStatus;}}
    public TankWeapon2 TankWeapon2 {get {return tankWeapon2;}}

}