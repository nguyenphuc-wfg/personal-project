using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankEffect : MonoBehaviour {
    private List<Effect> listEffect = new List<Effect>();
    public List<Effect> ListEffect {get {return listEffect;}}
    [SerializeField] private TankComponent _tankComponent;
    public Effect AddEffect(Effect effect){
        Effect effectInstance = Instantiate(effect, gameObject.transform);
        effectInstance.SetUp(_tankComponent);
        listEffect.Add(effectInstance);
        return effectInstance;
    }
    public void RemoveEffect(Effect effect){
        effect.OnBeforeDestroy();
        listEffect.Remove(effect);
        Destroy(effect.gameObject);
    }
    public void ClearEffect(){
        for (int i=0; i< listEffect.Count; i++){
            RemoveEffect(listEffect[i]);
            i--;
        }        
    }
    private void Update() {
        for (int i = 0; i < listEffect.Count; i++) {
            listEffect[i].OnUpdate();
        }   
    }
}