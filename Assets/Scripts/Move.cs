using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }
}
