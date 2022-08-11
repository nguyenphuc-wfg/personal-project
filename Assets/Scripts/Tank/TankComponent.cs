using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private TankWeapon tankShooting;
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;
    [SerializeField] private TankEffect tankEffect;
    [SerializeField] private TankWeapon tankWeapon;
    [SerializeField] private TankStatus tankStatus;

    public TankWeapon TankShooting {get {return tankShooting;}}
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
    public TankEffect TankEffect {get {return tankEffect;}}
    public TankWeapon TankWeapon {get {return tankWeapon;}}
    public TankStatus TankStatus {get {return tankStatus;}}

}