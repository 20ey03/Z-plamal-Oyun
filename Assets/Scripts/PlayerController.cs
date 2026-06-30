using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hiz = 5f;
    public float zipgucu = 400f;
    public float zipcarpani;
    public float y = 1f;
    public float tabanzip = 400f;
    public float maxzip = 1f;
    Rigidbody2D rb;
    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveH * hiz, rb.linearVelocity.y);
        if (Input.GetButton("Jump"))
        {
            zipcarpani += Time.deltaTime * y ;
            zipcarpani = Mathf.Clamp(zipcarpani, 0f, maxzip);
            Time.timeScale = 1f - zipcarpani;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (isGrounded == true)
            {
                rb.AddForce(new Vector2(0, tabanzip + zipgucu * zipcarpani));
                
            }
        zipcarpani = 0f;
        Time.timeScale = 1f;
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
