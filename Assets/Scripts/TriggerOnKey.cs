//////////code for TriggerOnKey/////
//////paste INSTEAD of existing code////////
///make sure the name of the script you are pasting into is EXACTLY TriggerOnKey/////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnKey : MonoBehaviour
{
    public float RotSpeed;///a field, type the degrees per frame to rotate will arrows held

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))//fire a bullet
        {

            GetComponent<ConstantForce>().enabled = true;

        }

        if (Input.GetAxis("Horizontal") < 0f)
        {

            transform.Rotate(Vector3.down * Time.deltaTime * RotSpeed);
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * RotSpeed);
        }

    }


}
