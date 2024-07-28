using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_move : MonoBehaviour
{
    private Animator anim;
    public MoveCube3 moveCube; 


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (moveCube != null && moveCube._objectDetected)
        {
            var detectedObject = moveCube.pp; // Get the position of the detected object
            if (detectedObject.x < -7)
            {
                Debug.Log("左側");
                
            }
            else if (-7 < detectedObject.x && detectedObject.x < 6)
            {
                Debug.Log("真ん中");
                
            }
            else if (6 < detectedObject.x)
            {
                Debug.Log("右側");
                
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "food")
        {
            anim.SetTrigger("ShellMove");
            //anim.SetBool("blRot", true);
            GetComponent<AudioSource>().Play();
           //ループつけてね
        }
    }
}
