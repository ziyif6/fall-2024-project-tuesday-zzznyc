using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;          
    public float projectileSpeed = 10f;  
    public float fireRate = 1.0f;       
    public enum Direction { Up, Down, Left, Right }
    public Direction shootDirection = Direction.Down;  
    private Vector2 directionVector; 

    void Start()
    {
        switch (shootDirection)
        {
            case Direction.Up:
                directionVector = Vector2.up;  
                break;
            case Direction.Down:
                directionVector = Vector2.down;  
                break;
            case Direction.Left:
                directionVector = Vector2.left;  
                break;
            case Direction.Right:
                directionVector = Vector2.right; 
                break;
        }
        InvokeRepeating("Shoot", 2.0f, fireRate);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = directionVector * projectileSpeed;
    }
}
