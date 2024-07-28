using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    // オブジェクトBのアニメーター
    public Animator objectBAnimator;

    private void Start()
    {
        // オブジェクトBのアニメーターがアサインされていることを確認
        if (objectBAnimator == null)
        {
            Debug.LogError("オブジェクトBのアニメーターがアサインされていません");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            //objectBAnimator.SetBool("abc", true);
            objectBAnimator.SetTrigger("smile_tg");
            GetComponent<AudioSource>().Play();
            Debug.Log("オブジェクトBのアニメーション再生");
        }
    }
}
