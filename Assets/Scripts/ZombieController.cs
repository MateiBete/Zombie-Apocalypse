using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    GameObject Player;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }
    void Start(){
        Player = GameObject.Find("Player");
    }

    void Update()
    {
      transform.position = Vector2.MoveTowards(
                            transform.position,
                            Player.transform.position,
                            1f * Time.deltaTime
        );
    }
}
