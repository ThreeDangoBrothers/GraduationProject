using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Janken : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveCube3 moveCube; 

    private float speed = 5.0f;
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "food")
        {
            Debug.Log("じゃんけん");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
    }
}
