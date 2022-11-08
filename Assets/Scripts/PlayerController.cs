using UnityEngine;


// This class will contain the properties & methods for the "Player" GameObject.
public class PlayerController : MonoBehaviour
{
    //
    // Properties
    //

    public Transform PlayerTransform; // The tranform componenet of the "PlayerRotate" GameObject.
    public Animator PlayerAnimator; // The animator controller for the GameObjects of the player and its children GameObjects.
    public float Sensitivity = 5f; // The value that'll modify how quickly the player rotates.

    Vector2 _rotationVector; // Will contain the x-axis & y-axis data on how much the player GameObject should be rotating.
    int _minYRotationValue = -65; // Maximum downward rotation.
    int _maxYRotationValue = 65; // Maximum upward rotation.
    int _minXRotationValue = -10;// Maximum left rotation.
    int _maxXRotationValue = 15; // Maximum right rotation.

    //
    // Methods
    //

    // Is called every frame.
    void Update()
    {
        RotatePlayer();
        PlayerAnimation();
    }

    // Rotates the player to where the user's mouse moves to.
    void RotatePlayer()
    {
        // Sets the rotationVector values to be the product of the x-axis & y-axis change of value and Sensitivity.
        _rotationVector.x += Input.GetAxis("Mouse Y") * Sensitivity;
        _rotationVector.y += Input.GetAxis("Mouse X") * Sensitivity;

        // Sets rotationVector value to a designated minRotationValue/maxRotationValue if the vector's value is too low/high.
        _rotationVector.x = Mathf.Clamp(_rotationVector.x, _minXRotationValue, _maxXRotationValue);
        _rotationVector.y = Mathf.Clamp(_rotationVector.y, _minYRotationValue, _maxYRotationValue);

        // Rotates the player (via "PlayerRotate" anchor GameObject) with the rotationVector values.
        PlayerTransform.rotation = Quaternion.Euler(
            _rotationVector.x, // Horizontal rotation
            _rotationVector.y, // Vertical rotation
            0f // z-axis locked at 0
            );
    }

    // Is the method that'll modify PlayerAnimator's paramters to make the player animate.
    void PlayerAnimation()
    {
        // If the player isn't holding down the spacebar, set SpacebarReleased to true (should have player animate down to cover).
        if (!Input.GetKey(KeyCode.Space))
        {
            PlayerAnimator.SetBool("SpacebarReleased", true);
        }
        // Else, set SpacebarReleased to false (should have player animate up to firing positon).
        else
        {
            PlayerAnimator.SetBool("SpacebarReleased", false);
        }
    }
}
