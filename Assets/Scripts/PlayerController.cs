using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float zipcarpani;
    private float y = 0.5f;
    public float tabanzip = 400f;
    Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveH * speed, rb.linearVelocity.y);
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            zipcarpani += Time.deltaTime * y ;
        }
        if (Input.GetButtonUp("Jump") && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, tabanzip + jumpForce * zipcarpani));
            zipcarpani = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
