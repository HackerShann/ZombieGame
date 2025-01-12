//////////code for ExplodeWhenHit/////
//////paste INSTEAD of existing code////////
///make sure the name of the script you are pasting into is EXACTLY ExplodeWhenHit//////


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ExplodeWhenHit : MonoBehaviour
{

    public GameObject TargetExplosion;
    public GameObject Targetvis;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "bullet")
        {
            //If the GameObject's tag matches the one you suggest


            TargetExplosion.SetActive(true);
            Targetvis.SetActive(false);

            Destroy(collision.gameObject);//destroy bullet

            Invoke("DestroyTargetContainer", 2.5f);//call func to destroy the whole target container, but give it a delay to 
        }


    }



    public void DestroyTargetContainer()
    {
        Destroy(transform.parent.gameObject);//destroy target container, the parent of the visible part
        ApplicationData.MakeNewBullet = true;//tell game manager to make a new bullet
        ApplicationData.MakeNewTarget = true;//tell game manager to make a new target

    }

}

