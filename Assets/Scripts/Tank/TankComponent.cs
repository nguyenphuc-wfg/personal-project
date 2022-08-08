using UnityEngine;

public class TankComponent : MonoBehaviour {
    [SerializeField] private TankShooting tankShooting;
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankHealth tankHealth;

    public TankShooting TankShooting {get {return tankShooting;}}
    public TankMovement TankMovement {get {return tankMovement;}}
    public TankHealth TankHealth {get {return tankHealth;}}
}