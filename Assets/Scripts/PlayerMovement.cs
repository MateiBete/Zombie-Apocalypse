using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0f;
    public Animator animator;
    public float Speed = 1000f;
    public Rigidbody2D rb;
    public GameObject YouDied;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Zombie"))
            Die();
    }

    private void Die()
    {
        YouDied.SetActive(true);
        Destroy(gameObject);
    }
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("w")){
            rb.AddForce(Vector2.up * Speed * Time.deltaTime);
            animator.SetBool("IsMoving", true );
        }
        if (Input.GetKey("s")){
            rb.AddForce(Vector2.down * Speed * Time.deltaTime);
            animator.SetBool("IsMoving", true );
        }
        if (Input.GetKey("d")){
            rb.AddForce(Vector2.right * Speed * Time.deltaTime);
            animator.SetBool("IsMoving", true );
        }
        else{
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKey("a")){
            rb.AddForce(Vector2.left * Speed * Time.deltaTime);
            animator.SetBool("IsMoving", true );
        }
        else{
            animator.SetBool("IsMoving", false);
        }
            
    }
}
