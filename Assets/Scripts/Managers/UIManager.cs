using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using Cysharp.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    public GameEvent Event;
    public GameEvent changeWeaponStorage;
    [SerializeField] private Text m_MessageText;
    [SerializeField] private Text _txtWeaponStorage;
    [SerializeField] private UIStats m_UIStats;
    [SerializeField] private WeaponStorage _weaponStorage;
    private void OnEnable() {
        Event.SubscribeListener(ChangeMessage);
        changeWeaponStorage.SubscribeListener(ChangeWeaponStorageUI);
        ChangeWeaponStorageUI();
    }

    private void OnDisable() {
        Event.UnSubscribeListener(ChangeMessage);
        changeWeaponStorage.UnSubscribeListener(ChangeWeaponStorageUI);
    }
    public void ChangeWeaponStorageUI(){
        _txtWeaponStorage.text = $"<color=#f54242>{_weaponStorage.gun01.GetType()}</color>  <color=#fcfcfc>{_weaponStorage.bulletName}</color>";
    }
    public void ChangeMessage(){
        m_MessageText.text = m_UIStats.message;
    }
}
