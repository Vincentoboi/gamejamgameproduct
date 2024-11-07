using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float playerPos;
    float AD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //ganska scuffed men fungerade kod som gör cameran i 2D sidescroller delen lite smooth och spicy

        playerPos = GameObject.Find("Robin").transform.position.x; // tar robins x position
        
        transform.position = new Vector3(playerPos + AD , 0, -10);

        if (Input.GetKey(KeyCode.D)&& AD > -4)
        {
            AD += -2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && AD < 4)
        {
            AD += 1f * Time.deltaTime;
        }
        else
        {        
            if (AD < 0)
            {
                AD += 1f * -AD * Time.deltaTime;
            }
            if (AD > 0)
            {
                AD -= 1f * AD * Time.deltaTime;
            }  
           
        }
    }
}
