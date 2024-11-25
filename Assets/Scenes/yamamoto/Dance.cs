using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dance : MonoBehaviour

{
    // Start is called before the first frame update
    public MoveCube3 moveCube; 

    private float speed = 5.0f;
    [SerializeField] Transform target;
    public Animator anim;
    public AudioClip collisionSound;
    private AudioSource audioSource;
    void Start()
    {
        // AudioSourceコンポーネントを追加して取得
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // 効果音を再生
        audioSource.PlayOneShot(collisionSound);
    }
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "food")
        {
            Debug.Log("ダンス");
            RemoveAllObjectsWithTags(new string[] { "Delete", "Janken", "Sample" });
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetTrigger("Dance");
            GetComponent<AudioSource>().Play();
            
            
        }
    }
    // 指定タグのすべてのオブジェクトを削除するメソッド
    private void RemoveAllObjectsWithTags(string[] tags)
    {
        foreach (string tag in tags)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }

            Debug.Log($"タグ '{tag}' のオブジェクトをすべて削除しました。");
        }
    }
}
