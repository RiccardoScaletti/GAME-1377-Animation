using Unity.VisualScripting;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 200f;
    public float jumpForce = 100f;
    private Vector2 movement;

    public bool isOnGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        movement = new Vector2(moveX, 0f);

        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            animator.SetBool("Jump2D", true);
            animator.SetBool("Run2D", false);
        }

        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (isOnGround) 
            {
                animator.SetBool("Run2D", true);
            }
            
        }    
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (isOnGround)
            {
                animator.SetBool("Run2D", true);
            }
        }
        else
        {
            animator.SetBool("Run2D", false);
        }
      
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            animator.SetBool("Jump2D", false);
        }
    }
}
