using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public MoveCube3 moveCube; 
    // Start is called before the first frame update
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
            SceneManager.LoadScene("StartGameScene");
            Debug.Log("ボタン遷移");
            //anim.SetTrigger("ShellMove");
            //anim.SetBool("blRot", true);
            //GetComponent<AudioSource>().Play();
           //ループつけてね
        }
    }
}
