using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System.Collections.Generic;

public class BuyMenuUI : MonoBehaviour
{
    public GameObject buyMenuPanel;
    public bool isBuyMenuOpen = false;
    public bool canControlPlayer;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI weaponCategory;
    public TextMeshProUGUI weaponPrice;
    public TextMeshProUGUI magzineRounds;
    public TextMeshProUGUI CurrentAmountText;
    public float CurrentAmount;
    public string currencySign;
    public Transform referencePose;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
        buyMenuPanel.SetActive(isBuyMenuOpen);
        Debug.Log($"Reference Pose at Start: {referencePose.transform.localPosition}");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            ToggleBuyMenu();
        }
    }

    void ToggleBuyMenu() {
        canControlPlayer = !canControlPlayer;
        isBuyMenuOpen = !isBuyMenuOpen;
        buyMenuPanel.SetActive(isBuyMenuOpen);

        if (UnityEngine.Cursor.lockState == CursorLockMode.Locked) {

            UnityEngine.Cursor.lockState = CursorLockMode.None;
            //Debug.Log("Cursor unlocked");
        }
        else 
        { 
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
            //Debug.Log("Cursor locked");
        }
        if (isBuyMenuOpen == true && UnityEngine.Cursor.lockState == CursorLockMode.Locked)
        {
            buyMenuPanel.SetActive(true);
        } 
    }
    public void ShowWeaponStats(ScriptableGuns SO) {
         weaponName.SetText(SO.gunName);
         weaponCategory.SetText(SO.gunCategory);
         weaponPrice.SetText(SO.gunPrice.ToString());
         magzineRounds.SetText(SO.roundCapacity.ToString());
    }

    public void ClearWeaponStats() {
         weaponName.text = ("");
         weaponCategory.text = ("");
         weaponPrice.text = ("");
         magzineRounds.text = ("");
    }

    public void SpawnGun(ScriptableGuns SO) {
        //Instantiate has four parameters: (GameObject to spawn, Vector3 position, Quaternion rotation, Transform parent)
        if (CurrentAmount < SO.gunPrice)
        {
            return;
        }
        if (CurrentAmount >= SO.gunPrice)
        {
            CurrentAmount -= SO.gunPrice;
            CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
            referencePose.transform.localPosition = SO.gunSpawnPosition;
            var spawnedWeapon = Instantiate(SO.gunPrefab, referencePose);
            spawnedWeapon.transform.localPosition = Vector3.zero;
            spawnedWeapon.transform.localRotation = Quaternion.identity;
            //Debug.Log($"Spawned {SO.gunName} at reference pose local position {referencePose.transform.localPosition}");
            //Debug.Log($"Reference Pose after spawining the weapon{referencePose.transform.localPosition
        }
        //else {
        //    Debug.Log("Insufficient funds to spawn this weapon.");
        //}
        if (CurrentAmount <= 0)
        {
            return;
        }
    }
}
