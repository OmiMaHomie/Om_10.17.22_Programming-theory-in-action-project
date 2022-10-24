using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Will be the script to effect the bullet's behavior in-game.
public class BulletBehavior : MonoBehaviour
{
    // Properties & Fields
    int bulletLifetime = 3;


    // Methods

    void Awake()
    {
        DestroyBulletAfterTime();
    }

    void OnTriggerEnter(Collider other)
    {
        print($"Collided with {other.name}");
        Destroy(gameObject);
    }

    // 
    public IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(bulletLifetime);
        print($"Bullet despawned");
        Destroy(gameObject);
    }
}
