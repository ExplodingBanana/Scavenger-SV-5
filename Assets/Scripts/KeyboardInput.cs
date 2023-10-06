using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelative = forward * vertical;
        Vector3 rightRelative = right * horizontal;

        Vector3 cameraRelative = forwardRelative + rightRelative + new Vector3(0, jump);

        _movement.Move(cameraRelative);
    }
}
