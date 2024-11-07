using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Loot : MonoBehaviour
{

    bool InRange = false;
    [SerializeField]public float value;

    private void Update()
    {
        if (InRange && Input.GetKeyUp(KeyCode.E))
        {
            //gameObject.SetActive(false);
          
        }
        if(InRange)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            InRange = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            InRange = false;

        }

    }
}
