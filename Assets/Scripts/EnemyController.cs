using UnityEngine;

// Will hold the methods & properties of enemies.
public class EnemyController : MonoBehaviour
{
    //
    // Properties
    //
   
    Transform PlayerTransform; // The player's transform.

    //
    // Methods
    //

    // Is called before the update method's called.
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Sets PlayerTransform to be the player's transform component.
    }

    // Is called when the script is first loaded.
    void Awake()
    {

    }

    // Is called every frame.
    void Update()
    {

    }
}
