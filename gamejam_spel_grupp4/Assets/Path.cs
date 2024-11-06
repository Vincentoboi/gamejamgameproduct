using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Path : MonoBehaviour
{

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
        Debug.Log(pointsIndex);
        if (pointsIndex == 6)
        {
            pointsIndex = 0;

        }


        if (pointsIndex <= Points.Length - 1)
        {
            //denhär skiten får npc att få till waypoint(ingen aning hur den funkar)
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
        }

        // så man kan kolla på waypoint framför en (ingen aning hur det funkar)
        Vector3 look = transform.InverseTransformPoint(Points[pointsIndex].transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);
    }
    void timerEnded()
    {
        pointsIndex += 1; // byter vilken waypoint man ska gå till
        targetTime += moveTimer; // resetar timer byt om du ska ändra tid
        Debug.Log("TIMER ENDED");
    }
 



}
