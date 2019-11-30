using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnimation : MonoBehaviour
{

    //Componenets
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    public void Activate() {
        anim.SetBool("isActive", true);
    }

    public void Deactivate() {
        anim.SetBool("isActive", false);
    }


    
}
