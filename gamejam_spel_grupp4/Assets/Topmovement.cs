using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Topmovement : MonoBehaviour
{
    float moveSpeed = 7;
    bool caught = false;
    public Animator anim;
    private float diagonalWalk;

    // Start is called before the first frame update
    void Start()
    {
        caught = false;
        transform.GetChild(2).gameObject.SetActive(false);
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
                transform.eulerAngles = new Vector3(0, 0, 0 + diagonalWalk);

            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.Play("PLayerTop_idle");
                Debug.Log("DU SLutade gå uppåt");
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
                anim.Play("Playertop_walk");
                transform.eulerAngles = new Vector3(0, 0, 180 + diagonalWalk);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                anim.Play("PLayerTop_idle");
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                anim.Play("Playertop_walk");
                //gameObject.transform.localRotation = quaternion.Euler(0,0, -90); <-- BLIR PÅ NPGOT SETT FUCKING -116.838 VEM FAN GJORDE ROTATION I UNITY
                transform.eulerAngles = new Vector3(0, 0, -90 + diagonalWalk);



            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                anim.Play("PLayerTop_idle");
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                 anim.Play("Playertop_walk");
                transform.eulerAngles = new Vector3(0, 0, 90 + diagonalWalk);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                anim.Play("PLayerTop_idle");
            }
            // DETHÄR ÄR MEGA SCUFFED FÖRLÅT TOBIAS
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                diagonalWalk = -45;
                Debug.Log("Går diagolant");
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                diagonalWalk = 45;

            }
            else 
            {
                diagonalWalk = 0;

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
           
            transform.GetChild(2).gameObject.SetActive(true);
            // visa Controls


        }

        

    }
    private void OnTriggerExit(Collider other)
    {

        Debug.Log("gömmer controls");
        transform.GetChild(2).gameObject.SetActive(false);
        //göm controls

    }
}

