using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_move : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "food")
        {
            m_Animator.SetBool("abc", true);
            Debug.Log("押されたyo");
            //GetComponent<AudioSource>().Play();
           //ループつけてね
           //     if (other.gameObject.tag == "food")
    //     {
    //         m_Animator.SetTrigger("smile_tg");
        }
    }
    
}
