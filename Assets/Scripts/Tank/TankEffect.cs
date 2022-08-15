using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Control add => remove effect 
public class TankEffect : MonoBehaviour
{
    private List<EffectData> listEffect = new List<EffectData>();

    [SerializeField] private TankComponent _tankComponent;
    [HideInInspector] public List<EffectData> ListEffect => listEffect;
    public bool AddEffect(EffectData effectdata)
    {
        if (effectdata.EffectPropsType == EffectPropsType.NEGATIVE)
        {
            for (int i = listEffect.Count - 1; i >= 0; i--)
            {
                if (listEffect[i].EffectLogic is EffectImmune)
                    return false;
            }
        }
        switch (effectdata.AddType)
        {
            case EffectAddType.NONE:
                {
                    effectdata.SetVFX(Instantiate(effectdata.VfxPrefab, this.transform));
                    listEffect.Add(effectdata);
                    effectdata.OnStart(_tankComponent);
                    break;
                }
            case EffectAddType.REPLACE:
                {
                    bool isReplace = false;
                    for (int i = 0; i < listEffect.Count; i++)
                    {
                        if (listEffect[i].EffectLogic.GetType() == effectdata.EffectLogic.GetType())
                        {
                            effectdata.VfxInstance = listEffect[i].VfxInstance;
                            listEffect[i] = effectdata;
                            isReplace = true;
                            break;
                        }
                    }
                    if (!isReplace)
                    {
                        effectdata.SetVFX(Instantiate(effectdata.VfxPrefab, this.transform));
                        listEffect.Add(effectdata);
                        effectdata.OnStart(_tankComponent);
                    }

                    break;
                }
            case EffectAddType.REPLACE_OVER:
                {
                    bool isReplace = false;
                    for (int i = 0; i < listEffect.Count; i++)
                    {
                        if (listEffect[i].EffectLogic.GetType() == effectdata.EffectLogic.GetType())
                        {
                            if (listEffect[i].CurrentLifeTime >= effectdata.CurrentLifeTime) break;
                            effectdata.VfxInstance = listEffect[i].VfxInstance;
                            listEffect[i] = effectdata;
                            isReplace = true;
                            break;
                        }
                    }
                    if (!isReplace)
                    {
                        effectdata.SetVFX(Instantiate(effectdata.VfxPrefab, this.transform));
                        listEffect.Add(effectdata);
                        effectdata.OnStart(_tankComponent);
                    }
                    break;
                }
            case EffectAddType.CUMULATIVE:
                {
                    for (int i = 0; i < listEffect.Count; i++)
                    {
                        if (listEffect[i].EffectLogic.GetType() == effectdata.EffectLogic.GetType())
                        {
                            if (listEffect[i].EffectLogic.GetType() == effectdata.EffectLogic.GetType())
                            {

                            }
                        }
                    }
                    break;
                }
        }
        return true;
    }

    public void RemoveEffect(EffectData effect)
    {
        effect.OnRemoveEffect(_tankComponent);
        Destroy(effect.VfxInstance);
        listEffect.Remove(effect);
    }

    private bool CheckEffectAlive(EffectType type)
    {
        foreach (var effect in listEffect)
            if (effect.Type == type)
                return true;
        return false;
    }

    public void ClearEffect()
    {
        for (int i = listEffect.Count - 1; i >= 0; i--)
        {
            RemoveEffect(listEffect[i]);
        }
    }
    private void Update()
    {
        for (int i = listEffect.Count - 1; i >= 0; i--)
        {
            listEffect[i].OnUpdate(_tankComponent);
        }
    }
}