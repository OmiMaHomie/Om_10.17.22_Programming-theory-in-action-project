using UnityEngine;

public class GunController : MonoBehaviour
{
    // Properties & Fields
    [SerializeField] GameObject bullet; // Set in editor. Is the gameObject "Bullet" (is a prefab).


    // Methods

    public void FireBullet()
    {
        GameObject bullet = Instantiate(this.bullet);
        print($"Bullet spawned");

        bullet.transform.parent = transform;
        print($"Bullet's position set");

        bullet.GetComponent<Rigidbody>().AddForce(Vector3.back * 30, ForceMode.Impulse);
        print($"Bullet fired");
    }
}
