using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMainMenu : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start(){
        animator.SetBool("faded", true);
        StartCoroutine(afterFading());
    }

    IEnumerator afterFading(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
