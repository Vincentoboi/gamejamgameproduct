using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Topmovement : MonoBehaviour
{
    float moveSpeed = 7;
    bool caught = false;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(caught == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
                anim.Play("Playertop_walk");
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.Play("PLayerTop_idle");
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
            }
        }
        if (caught == false) 
        {
            transform.GetChild(1).gameObject.SetActive(false); // ser till att fucking icon inte alltid existerar


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "NextLevel")
	    {
            Debug.Log("Box touched");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == "PreviousLevel")
	    {
            Debug.Log("Box touched");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.tag == "NPC" && caught == false)
        {

            caught = true;
            Debug.Log("Caught");

            transform.GetChild(1).gameObject.SetActive(true); //spawnar Caught iconen
            Debug.Log("YOu got Caught, Making Shit Happen");

        }
        if (collision.tag == "Loot") ;
        {
           
            transform.GetChild(1).gameObject.SetActive(true);



        }

        

    }
    private void OnTriggerExit(Collider other)
    {
        transform.GetChild(1).gameObject.SetActive(false);


    }
}

