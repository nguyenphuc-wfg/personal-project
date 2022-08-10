using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private Weapon tankShooting;
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;
    [SerializeField] private TankEffect tankEffect;
    [SerializeField] private TankStatus tankStatus;

    public Weapon TankShooting {get {return tankShooting;}}
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
    public TankEffect TankEffect {get {return tankEffect;}}
    public TankStatus TankStatus {get {return tankStatus;}}

    public void OnStun(){
        tankShooting.enabled = false;
        tankMovement.enabled = false;
    }
    public void OffStun(){
        tankShooting.enabled = true;
        tankMovement.enabled = true;
    }
}