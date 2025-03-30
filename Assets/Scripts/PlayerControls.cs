using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    float xThrow, yThrow;
    float speed = 12f;
    float rotationSpeed = 2f;
    [Header ("General Setup Variables")]
    [Tooltip ("How far up the screen can the player move horizontally.")] 
    [SerializeField] float xRange = 10;
    [Tooltip("How far up the screen can the player move vertically.")]
    [SerializeField] float yRange = 5;
    [Tooltip("How pronounced will the tip of the ship aim towards the center of the screen.")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("How pronounced will the tip of the ship rotate vertically upon input.")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 1f;
    [Tooltip("How pronounced will the tip of the ship rotate horizontally upon input.")]
    [SerializeField] float controlRollFactor = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        strafingMovement();
        rotateMovement();
    }

    void strafingMovement()
    {    
        xThrow = Input.GetAxis("Horizontal");
        float newXValue = xThrow * Time.deltaTime * speed + transform.localPosition.x;
        float clampedXPos = Mathf.Clamp(newXValue, -xRange, xRange);

        yThrow = Input.GetAxis("Vertical");
        float newYValue = yThrow * Time.deltaTime * speed + transform.localPosition.y;
        float clampedYPos = Mathf.Clamp(newYValue, -yRange,yRange+2);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);    
    }
    void rotateMovement()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = -transform.localPosition.x * positionYawFactor;
        float roll = -xThrow * controlRollFactor;

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed);
        //transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
       
    }
}
