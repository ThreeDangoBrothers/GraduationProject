using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Crab_move : MonoBehaviour
{
    private int x;
    private Vector3 mouse;
    private Vector3 target;
    private int direction;


    void Start ()
    {
        direction=1;

    }
 


    void Update()
    {
        transform.Translate(new Vector3(0, 0, direction*-0.006f));

        
    }
 
     private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "fish")
        {
            
            direction=direction*-1;
        }
        
       
    }
}