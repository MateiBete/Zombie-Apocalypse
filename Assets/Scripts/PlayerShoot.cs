using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject BulletPrefab;
    public Text Score;
    public float Speed = 1000f;
    public float MaxExistenceTime = 0.5f;
    private GameObject bullet;
    private Vector3 shootDirection;
    private bool canShoot = true;

    private void Shoot()
    {
        bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        BulletDestroyer bulletDestroyer = bullet.GetComponent<BulletDestroyer>();
        bulletDestroyer.MaxExistenceTime = MaxExistenceTime;
        bulletDestroyer.Score = Score;
        bullet.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(shootDirection.x, shootDirection.y).normalized * 3 * Speed);
    }

    public void DrawLine(Vector3 start, Vector3 end, Color color, float width)
    {
        // Set color
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        // Set width
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        // Set line count which is 2
        lineRenderer.positionCount = 2;

        // Set the postion of both two lines
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    void Update()
    {
        if (canShoot)
        {
            Vector3 lineStart = shootDirection + transform.position;
            Vector3 lineEnd = transform.position;
            lineStart.z = 0;
            lineEnd.z = 0;

            lineRenderer.enabled = true;
            DrawLine(lineStart, lineEnd, Color.white, 0.1f);

            shootDirection = Input.mousePosition;
            shootDirection.z = 0;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection -= transform.position;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                canShoot = false;
                Shoot();
            }
        }
        else
            lineRenderer.enabled = false;

        if (bullet == null && !canShoot)
            canShoot = true;
    }
}
