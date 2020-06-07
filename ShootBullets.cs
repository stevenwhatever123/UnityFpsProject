using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    // Bullet Object
    public GameObject bulletPrefab;

    // Component References
    public Camera camera;
    public Animator animator;

    // Boolean to check if the gun is firing
    public bool firing;

    // Update is called once per frame
    void Update()
    {
        // If left mouse is clicked
        // Check if the gun is firing, if not we fire the gun
        // And change the firing condition to true;
        if(Input.GetMouseButtonDown(0)){
            if(!firing){
                firing = true;
                StartCoroutine(GunFire());
            }
        }
    }

    IEnumerator GunFire(){
        animator.SetBool("isFiring", true);
        GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = transform.position + camera.transform.forward; 
        bulletObject.transform.forward = camera.transform.forward; 
        yield return new WaitForSeconds(0.5f);
        firing = false;
        animator.SetBool("isFiring", false);
    }
}
