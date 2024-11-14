using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTouch : MonoBehaviour
{
    private Animator anim;
    public MoveCube3 moveCube; 


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "food")
        {
            SceneManager.LoadScene("okuyama");
            Debug.Log("ボタン遷移");
            //anim.SetTrigger("ShellMove");
            //anim.SetBool("blRot", true);
            //GetComponent<AudioSource>().Play();
           //ループつけてね
        }
    }
}
