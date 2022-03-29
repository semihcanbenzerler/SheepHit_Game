using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;
    public Transform haySpawnPoint;
    public float shootInterval;
    private float shootTimer;

  

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

   private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput<0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnPoint.position, Quaternion.identity);
    }
    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }
}
