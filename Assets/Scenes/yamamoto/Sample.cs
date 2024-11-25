using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class   Sample : MonoBehaviour
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
            Debug.Log("サンプル");
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            RemoveAllObjectsWithTags(new string[] { "Delete", "Janken", "Dance" });
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
