using System.Collections;
using UnityEngine;

// This script will hold all the properties & methods for the "Gun" GameObject.
public class GunController : MonoBehaviour
{
    //
    // Properties
    //

    public GameObject Bullet; // Bullet GameObject.
    public Transform GunSpawnTransform; // Transform for GunSpawn GameObject.
    public float BulletForce = 150f; // Value of force that bullet will be shot out from gun.
    public float _firerate = .25f; // The delay, in seconds, that player has to wait until being able to fire gun again.
    public int _maxAmmo = 6; // The magazine capacity of the gun.

    protected int _currentAmmo = 6; // The current # of bullets the gun has currently.
    protected bool _canFire = true; // Checks to see if the gun is able to fire.

    //
    // Methods
    //

    // Is called every frame.
    void Update()
    {
        // Checks if the "Player" GameObject is currently in the "PlayerIdle" animation.
        if (GameObject.Find("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle"))
        {
            // Checks if left-mouse-button is pressed.
            if (Input.GetMouseButtonDown(0) && _currentAmmo > 0 && _canFire)
            {
                StartCoroutine(Fire());
            }
        }
        // Else, if in cover or transitioning animation.
        else
        {
            Reload();
        }
    }

    // Fires a new Bullet GameObject.
    protected IEnumerator Fire()
    {
        // Sets _canFire to false so that you can't fire gun again until the method finishs.
        _canFire = false;

        // Instatiates a new Bullet GameObject.
        GameObject bullet = Instantiate(Bullet);

        // Sets bullet to ignore collisions between the bullet and the gun.
        Physics
            .IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

        // Sets the position & rotation of bullet to be the same as GunSpawnTransform.
        bullet.transform.position = GunSpawnTransform.position;
        bullet.transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );

        // Adds force to bullet so that it's shot forward with BulletForce value all at once (Impulse).
        bullet.GetComponent<Rigidbody>()
            .AddForce(GunSpawnTransform.forward * BulletForce, ForceMode.Impulse);

        // Decrements _currentAmmo by 1.
        _currentAmmo--;

        // Delays the method for _firerate seconds, then sets _canFire to true.
        yield return new WaitForSeconds(_firerate);
        _canFire = true;

        print($"{_currentAmmo}/{_maxAmmo}");
    }

    // Sets _currentAmmo back to _maxAmmo.
    protected void Reload() => _currentAmmo = _maxAmmo;
}
