using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] coordonate; 
    private int pozitie = 0;
    [SerializeField] private float speed = 2f;
    void Update()
    {
        if(Vector2.Distance(coordonate[pozitie].transform.position,transform.position)< .1f)
        {
            pozitie++;
            if(pozitie>=coordonate.Length)
            {
                pozitie=0;
            }
        }    
        transform.position=Vector2.MoveTowards(transform.position,coordonate[pozitie].transform.position,speed*Time.deltaTime);
    }
    
}
