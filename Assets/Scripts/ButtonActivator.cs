using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    private Animator anim;
    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターを取得
        anim = gameObject.GetComponent<Animator>();
        
        // サウンドが設定されていなければ、自動で取得
        if (buttonSound == null)
        {
            buttonSound = GetComponent<AudioSource>();
        }
    }

    // プレイヤーがボタンに触れたときに発動するトリガー
    private void OnTriggerEnter(Collider other)
    {
        // "button"タグを持つオブジェクトに触れたら
        if (other.gameObject.tag == "button")
        {
            // ボタンのアニメーションを起動する
            anim.SetTrigger("ButtonPressed");
            
            // サウンドを再生
            if (buttonSound != null)
            {
                buttonSound.Play();
            }
            
            Debug.Log("ボタンが起動されました！");
        }
    }
}
