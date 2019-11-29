using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnimation : MonoBehaviour
{

    //Componenets
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    public void setActive() {
        anim.SetBool("isActive", true);
        Debug.Log("ACtive");
    }

    public void setInactive() {
        anim.SetBool("isActive", false);
        Debug.Log("inACtive");
    }


    
}
