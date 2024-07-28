using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
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
            objectBAnimator.SetTrigger("unsmile_tg");
            Debug.Log("オブジェクトBのアニメーション再生");
            GetComponent<AudioSource>().Play();
        }
    }
}
