//////////code for catch miss script/////
//////paste INSTEAD of existing code////////
///make sure the name of the script you are pasting into is EXACTLY CatchMissScript//////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CatchMissScript : MonoBehaviour
{

    public AudioSource MissedSound; //defines the audio source that has the "miss" sound in it

    public Transform MissImpactPrefab;//defines the prefab that will be the "hole" in the wall,with impact explosion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision MyBulletcollision)
    {
        //Check for a match with the specified tag on any GameObject that collides with your GameObject
        if (MyBulletcollision.gameObject.tag == "bullet")
        {

            Destroy(MyBulletcollision.gameObject);

            ContactPoint contact = MyBulletcollision.contacts[0];

            Vector3 pos = contact.point;
            Instantiate(MissImpactPrefab, pos, Quaternion.identity);
            //Quaternion.identity is the rotation of this object, the wall. so the hole will be perfectly "stuck" to the wall, like a poster

            MissedSound.pitch = UnityEngine.Random.Range(0.4f, 1.6f);//randomize pitch of sound so it doesn't sound the same every time
            MissedSound.Play();
            ApplicationData.MakeNewBullet = true;//tell game manager to make a new bullet
        }


    }







}

