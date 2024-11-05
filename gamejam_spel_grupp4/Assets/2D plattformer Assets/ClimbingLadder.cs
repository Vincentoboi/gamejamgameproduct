using UnityEngine;

public class ClimbingLadder : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed, dirX, dirY;
    public bool climbingAllowed { get; set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (climbingAllowed)
        {
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        }
    }
    private void FixedUpdate()
    {
        if (climbingAllowed)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(dirX, dirY);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
    }
}
