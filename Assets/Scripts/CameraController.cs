using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 0;
    public float RotationX = 0;
    public BuyMenuUI buyMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (buyMenuUI.canControlPlayer == false)
        {
            return;
        }
        else {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            RotationX -= mouseY;
            RotationX = Mathf.Clamp(RotationX, -90f, 90f);
            transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
            playerTransform.Rotate(Vector3.up * mouseX);
            Debug.Log(sensitivity);
        }
    }  
}
