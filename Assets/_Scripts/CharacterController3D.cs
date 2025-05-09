using UnityEngine;

public class CharacterController3D : MonoBehaviour
{

    private Animator animator;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.SetBool("Forward", true);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            animator.SetBool("Backward", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("Right", true);
            
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("Left", true);
        }
        else
        {
            Debug.Log("FALSE");
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
    }
}
