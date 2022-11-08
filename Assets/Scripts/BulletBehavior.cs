using System.Collections;
using UnityEngine;

// This script will contain the behavior for the "Bullet" GameObject.
public class BulletBehavior : MonoBehaviour
{
    //
    // Properties
    //

    public float BulletLifetime = 3f; // Is the maximum lifetime of bullet GameObject before despawning.

    //
    // Methods
    //

    // Runs when a bullet is loaded.
    void Awake()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    // Runs when the bullet enters the collider of any other GameObject.
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroys itself
    }

    // Sets the bullet GameObject to be destroyed after bulletLifeTime seconds.
    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(BulletLifetime);
        Destroy(gameObject);
    }
}
