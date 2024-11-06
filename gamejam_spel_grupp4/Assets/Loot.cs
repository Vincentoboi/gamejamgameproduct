using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Loot : MonoBehaviour
{

    bool InRange = false;
    [SerializeField] float value;

    private void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
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
