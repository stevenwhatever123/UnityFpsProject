using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet firing speed
    public float speed = 16f;

    // Bullet life duration
    public float lifeDuration = 2f;

    // Bullet life counter
    public float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;
        if(lifeTimer <=- 0f){
            Destroy(this.gameObject);
        }
    }

}
