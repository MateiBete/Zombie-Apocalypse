using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletDestroyer : MonoBehaviour
{
    public Text Score;
    public float MaxExistenceTime;
    private float timeSinceExistence;

    void Update()
    {
        timeSinceExistence += 1 * Time.deltaTime;
        if (timeSinceExistence >= MaxExistenceTime) 
            Hit(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Player"))
            Hit(other.gameObject.CompareTag("Zombie"));
    }

    private void Hit(bool changeScore)
    {
        Destroy(gameObject);
        if (changeScore)
        {
            Statistics.Score++;
            Score.text = "Score: " + Statistics.Score;
        }
    }
}
