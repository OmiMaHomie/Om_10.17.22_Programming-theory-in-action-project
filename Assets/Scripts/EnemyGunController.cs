using System.Collections;
using UnityEngine;

// Is an extension to the GunController class. Is the class that'll contain the methods & properties for enemy guns.
public class EnemyGunController : GunController
{
    //
    // Properties
    //

    float _enemyDelay = 3f; // The amount of time, in seconds, that the enemy will taking reloading until firing again.
    bool _isReloading = false; // Bool to check if the enemy is reloading or not.

    //
    // Constructor
    //

    // Sets _firefate to a custom value, while retaining all of the default values from GunController class.
    public EnemyGunController()
    {
        _firerate = .5f;
    }

    //
    // Methods
    //

    // Is called every frame.
    void Update()
    {
        AutomatedFire();
    }

    // Automated firing method for the enemy.
    void AutomatedFire()
    {
        // Checks to see if _currentAmmo is greater than 0 and _canFire is true.
        if (_currentAmmo > 0 && _canFire)
            StartCoroutine(Fire());

        // Checks to see if _currentAmmo is at 0.
        if (_currentAmmo == 0 && !_isReloading)
            StartCoroutine(DelayReload());
    }

    // Delays the enemy's reload by _enemyDelay seconds
    IEnumerator DelayReload()
    {
        // Sets _isReloading to false so code isn't run again whilst realoding.
        _isReloading = true;

        // Delays the program for _enemyDelay seconds.
        yield return new WaitForSeconds(_enemyDelay);

        // Reloads the gun and sets _isReloading to true so enemy can reload again.
        Reload();
        _isReloading = false;
    }
}
