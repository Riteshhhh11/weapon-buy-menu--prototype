using UnityEngine;
public class Move : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public BuyMenuUI buyMenuUI;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove() {
        if (buyMenuUI.canControlPlayer == false)
        {
            return;
        }
        else {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
    }
}
