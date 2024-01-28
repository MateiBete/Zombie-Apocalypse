using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
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

    void Update()
    {
        if (Input.GetKey("w"))
            rb.AddForce(Vector2.up * Speed * Time.deltaTime);

        if (Input.GetKey("s"))
            rb.AddForce(Vector2.down * Speed * Time.deltaTime);

        if (Input.GetKey("d"))
            rb.AddForce(Vector2.right * Speed * Time.deltaTime);

        if (Input.GetKey("a"))
            rb.AddForce(Vector2.left * Speed * Time.deltaTime);
    }
}
