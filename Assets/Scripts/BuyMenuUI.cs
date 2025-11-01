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
    public Transform GunHolderTransform;
    //public TextMeshProUGUI weaponRoundCapacity;

    //public ScriptableGuns SO;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        if (buyMenuPanel == null) {
            //Debug.LogError("BuyMenuPanel not found in the scene.");
        }
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
        Instantiate(SO.gunPrefab, GunHolderTransform);
        Debug.Log("Spawned " + SO.gunName);
    }
}
