using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjPool {
    public GameObject gameObject;
    public int count;
    public string tag;
}

public class ObjectPooling : MonoBehaviour 
{
    private static ObjectPooling instance;
    public static ObjectPooling Instance {get{return instance;}}

    [SerializeField] List<ObjPool> listPrefabs = new List<ObjPool>();

    private Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        CreatePool();
    }

    private void CreatePool(){
        foreach (ObjPool item in listPrefabs){
            List<GameObject> prefabs = new List<GameObject>();
            for (int i = 0; i < item.count; i++) {
                GameObject obj = CreateNewObject(item.gameObject);
                prefabs.Add(obj);
            }
            pool.Add(item.tag, prefabs);
        }
    }
    public GameObject GetObject(string tag, Vector3 pos, Quaternion rot){
        if (!pool.ContainsKey(tag)) return null;

        foreach (GameObject item in pool[tag]) {
            if (!item.activeSelf) {
                item.transform.position = pos;
                item.transform.rotation = rot;
                item.SetActive(true);
                return item;
            }
        }

        foreach (ObjPool item in listPrefabs){
            if (item.tag != tag) continue;
            GameObject obj = CreateNewObject(item.gameObject);
            pool[tag].Add(obj);
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public GameObject CreateNewObject(GameObject obj){
        GameObject objInstance = Instantiate(obj);
        objInstance.SetActive(false);
        return objInstance;
    }

    public void ReturnAllPool(){
        foreach (var item in pool) {
            foreach (GameObject obj in item.Value) {
                obj.SetActive(false);
            }
        }
    }
}