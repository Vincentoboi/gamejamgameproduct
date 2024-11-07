using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Topmovement : MonoBehaviour
{
    float moveSpeed = 7;
    public bool caught = false;
    public Animator anim;
    private float diagonalWalk;
    float sceneResetTimer = 3;
    private float cashStolen = 0;
    public float itemValue;
    [SerializeField] private TextMeshProUGUI cashAmountText;
    [SerializeField] private TextMeshProUGUI caughtText;
    [SerializeField] private Transform nextTeleportTarget;
    [SerializeField] private Transform previousTeleportTarget;

    // Start is called before the first frame update
    void Start()
    {
        caught = false;
        //transform.GetChild(2).gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
          
        cashAmountText.text = "Total Robbed Value: " + cashStolen + "$";

        if(Input.GetButtonDown("E"))
        {
            Debug.Log("DU TRYCKTE PÅ E");

        }

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
            // DETHÄR ÄR SCUFFED FÖRLÅT TOBIAS
            
            // Gör så han kollar diagonal när han går diagonalt
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
            caughtText.text = " ";
        }
        if (caught == true)
        {

            caughtText.text = "YOU GOT CAUGHT";

            sceneResetTimer -= Time.deltaTime; 
            if (sceneResetTimer <= 0) // reseta level
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("RESETING LEVEL");

            }
        }

        //Debug.Log(sceneResetTimer); 

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
        if (collision.tag == "Teleporter") //teleporta fra o tillbacka
        {
            gameObject.transform.position = nextTeleportTarget.transform.position;
        }
        if (collision.tag == "TeleporterBack")
        {
            gameObject.transform.position = previousTeleportTarget.transform.position;
        }
    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //för någon dum anledning börjar denhär koden fungera några sekunder efter man har startat scenen????

        //gör så att du får pängar av att plocka upp items
        if (collision.tag == "Loot" && Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("du plocka upp skit");
            itemValue = collision.gameObject.GetComponent<Loot>().value;
            cashStolen += itemValue;
            Debug.Log(cashStolen);
            Destroy(collision.gameObject);
        }
    }
}

