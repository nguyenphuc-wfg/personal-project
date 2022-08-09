using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private Weapon tankShooting;
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;

    public Weapon TankShooting {get {return tankShooting;}}
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
}