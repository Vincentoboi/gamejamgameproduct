using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private float pointAmount;

    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float moveTimer;

    private int pointsIndex;
    float targetTime;
    // Start is called before the first frame update
    void Start()
    {
        targetTime += moveTimer;
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
        //Debug.Log(pointsIndex);
        if (pointsIndex == pointAmount) // reset poojtn
        {
            pointsIndex = 0;

        }


        if (pointsIndex <= Points.Length - 1)
        {
            //denhär skiten får npc att få till waypoint
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
        }

        // gör så npc kollar på nästa waypoint (fattar nästan hur den funkar) ¯\_(ツ)_/¯
        Vector3 look = transform.InverseTransformPoint(Points[pointsIndex].transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);
    }
    // dethär är lite scuffed honestly  \/
    void timerEnded()
    {
        pointsIndex += 1; // byter vilken waypoint man ska gå till
        targetTime += moveTimer; // resetar timer 
        Debug.Log("TIMER ENDED");
    }
 



}
