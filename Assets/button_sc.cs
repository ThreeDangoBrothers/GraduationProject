using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_sc : MonoBehaviour
{
    // アニメーター
    private Animator m_Animator = null;

    //-----------------------------------------------------------------------
    // Unityメゾット
    //-----------------------------------------------------------------------

    // 初期化処理
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        Debug.Log("押された!");
        m_Animator.SetTrigger("smile_tg");
    }
    public void OnClick2()
    {
        Debug.Log("押された2!");
        m_Animator.SetTrigger("unsmile_tg");
    }

    // private void OnTriggerEnter(Collider other)
    // {
    
    //     if (other.gameObject.tag == "food")
    //     {
    //         m_Animator.SetTrigger("smile_tg");
    //         Debug.Log("押されたyo");
    //         //GetComponent<AudioSource>().Play();
    //        //ループつけてね
    //     }
    // }
    
}
