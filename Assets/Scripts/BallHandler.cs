using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D currentBallRigidbody;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.IsPressed())
        {
            currentBallRigidbody.isKinematic = false;
            return; // Don't run any of the code after this line.
        }

        currentBallRigidbody.isKinematic = true;
        
        // To store finger position
        // if we touch on the screen, read where the position is and log it out to the console.
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        
        //Convert the screen position to game world position.
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        currentBallRigidbody.position = worldPosition;
    }
}
