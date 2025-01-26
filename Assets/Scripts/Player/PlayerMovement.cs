using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd2d;
    Animate animate;
    Vector3 movementVector;

    [SerializeField] private float speed = 10.0f;

    private float speedModifier = 1.25f;


    private void Awake()
    {
        animate = GetComponent<Animate>();
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x == 0 && movementVector.y == 0)
        {
            rgbd2d.linearVelocity = new Vector3(0, 0, 0);
            return;
        }
        rgbd2d.linearVelocity = (movementVector * speed  * speedModifier) * Time.fixedDeltaTime;
    }

    private void Animate()
    {
        animate.horizontal = movementVector.x;
        animate.Vertical = movementVector.y;
    }

}
