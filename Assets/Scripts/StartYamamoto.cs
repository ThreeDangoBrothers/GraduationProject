using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartYamamoto : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveCube3 moveCube; 
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
            SceneManager.LoadScene("Yamamoto");
            Debug.Log("yamamoto遷移");
            //anim.SetTrigger("ShellMove");
            //anim.SetBool("blRot", true);
            //GetComponent<AudioSource>().Play();
           //ループつけてね
        }
    }
}