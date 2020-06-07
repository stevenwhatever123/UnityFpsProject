using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Component References
    public Transform player;
    public MovingScript movingScript;
    public Animator animator;

    // Offset for the camera
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    // Z-axis for camera rotation
    public float cameraRotation;
    public float temp; // For saving the cameraRotation;

    // Update is called once per frame
    void Update()
    {
        // Setting the distance between the player and the camera
        transform.position.Set(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        
        // Update the isWallL and isWallR everytime. 
        // If conditions are met, we perform the animation that we set
        animator.SetBool("isWallL", movingScript.isWallL);
        animator.SetBool("isWallR", movingScript.isWallR);

        // If we are climbing the wall on the player's right
        // We rotate the camera to the Right
        if(movingScript.isWallR){
            temp = -cameraRotation;
        }

        // Rotate the camera
        if(movingScript.cameraRotated){
            transform.Rotate(0, 0, temp);
        } else {
            transform.Rotate(0, 0, 0);
        }
    }
    
}
