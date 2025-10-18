using UnityEngine;
using UnityEngine.UIElements;

public class BuyMenuUI : MonoBehaviour
{
    public GameObject buyMenuPanel;
    public bool isBuyMenuOpen = false;
    public bool canControlPlayer;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        if (buyMenuPanel == null) {
            Debug.LogError("BuyMenuPanel not found in the scene.");
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
            Debug.Log("Cursor unlocked");
        }
        else 
        { 
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
            Debug.Log("Cursor locked");
        }
        if (isBuyMenuOpen == true && UnityEngine.Cursor.lockState == CursorLockMode.Locked)
        {
            buyMenuPanel.SetActive(true);
        } 
    }
}
