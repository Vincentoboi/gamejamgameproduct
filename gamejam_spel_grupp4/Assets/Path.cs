using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    private int pointsIndex;
    float targetTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = Points[pointsIndex].transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        Debug.Log(pointsIndex);
        if (pointsIndex == 6)
        {
            pointsIndex = 0;

        }


        if (pointsIndex <= Points.Length - 1)
        {



            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

          
        }

    }
    void timerEnded()
    {
        pointsIndex += 1;
        targetTime += 3f;
        Debug.Log("TIMER ENDED");
    }




}
