using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjPool {
    public Rigidbody gameObject;
    public int count;
}

public class ObjectPooling : MonoBehaviour 
{
    private static ObjectPooling instance;
    public static ObjectPooling Instance {get{return instance;}}

    [SerializeField] ObjPool bullet;

    private List<Rigidbody> bulletPool = new List<Rigidbody>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        CreatePool(bullet, bulletPool);
    }

    private void CreatePool(ObjPool objp, List<Rigidbody> pool){
        for (int i = 0; i < objp.count; i++) {
            Rigidbody obj = CreateNewGO(objp.gameObject);
            pool.Add(obj);
        }
    }

    public Rigidbody GetBullet(){
        foreach (Rigidbody item in bulletPool) {
            if (!item.gameObject.activeSelf) {
                return item;
            }
        }
        Rigidbody obj = CreateNewGO(bullet.gameObject);
        bulletPool.Add(obj);
        return obj;
    }

    public Rigidbody CreateNewGO(Rigidbody go){
        Rigidbody obj = Instantiate(go, Vector3.zero, Quaternion.identity); 
        obj.gameObject.SetActive(false);
        return obj;
    }
}