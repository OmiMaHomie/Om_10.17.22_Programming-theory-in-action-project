using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Properties & Fields
    [SerializeField] GameObject gun; // Set in editor. Is the gameObject "Gun".


    // Methods

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.GetComponent<GunController>().FireBullet();
        }
    }
}
