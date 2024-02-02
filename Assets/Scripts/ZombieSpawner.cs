using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public GameObject Player;
    public int AmountOfZombiesToSpawn;

    // FixedUpdate este executat de 60 de ori pe secunda
    void FixedUpdate()
    {
        if (Player == null) 
        {
            Destroy(gameObject);
            return;
        }

        if (transform.childCount < 1)
        {
            for (int i = 0; i < AmountOfZombiesToSpawn; i++)
            {
                GameObject zombie = Instantiate(ZombiePrefab, transform);
                zombie.transform.position = GetRandomPosition();

                while (Vector2.Distance(zombie.transform.position, Player.transform.position) < 4f)
                    zombie.transform.position = GetRandomPosition();
            }
        }
    }

    Vector2 GetRandomPosition() => new Vector2(Random.Range(-10, 10), Random.Range(-1, 4));
}
