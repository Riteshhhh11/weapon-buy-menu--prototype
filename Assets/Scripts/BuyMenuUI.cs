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
    public int CurrentAmount;
    public int maxAmount = 9000;
    public string currencySign;
    public Transform referencePose;
    public int gunSpawnCount = 0;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
        buyMenuPanel.SetActive(isBuyMenuOpen);
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
        }
        else 
        { 
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
        }
    }
    public void ShowWeaponStats(ScriptableGuns SO) {
         weaponName.SetText("Name: " + SO.gunName);
         weaponCategory.SetText("Type: " + SO.gunCategory);
         weaponPrice.SetText("Price: " + SO.gunPrice.ToString());
         magzineRounds.SetText("Rounds: " + SO.roundCapacity.ToString());
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
        if (CurrentAmount >= SO.gunPrice && gunSpawnCount == 0)
        {
            gunSpawnCount++;
            CurrentAmount -= SO.gunPrice;
            CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
            referencePose.transform.localPosition = SO.gunSpawnPosition;
            var spawnedWeapon = Instantiate(SO.gunPrefab, referencePose);
            spawnedWeapon.transform.localPosition = Vector3.zero;
            spawnedWeapon.transform.localRotation = Quaternion.identity;
        }
        if (CurrentAmount <= 0)
        {
            return;
        }
    }
    public void SellGun(ScriptableGuns SO)
    {
        if (gunSpawnCount > 0)
        { 
            gunSpawnCount--;
            CurrentAmount += SO.gunPrice;
            Destroy(referencePose.GetChild(0).gameObject);
            CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
            if (CurrentAmount > maxAmount) {
                CurrentAmount = maxAmount;
                CurrentAmountText.SetText(CurrentAmount + currencySign.ToString());
            }
        }
        else {
            return;
        }
    }
}
