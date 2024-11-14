using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExploder : MonoBehaviour
{
    public ParticleSystem ps;

    GameObject obj;

    private Vector3 mousePosition;
    void Start()
    {
        obj = GameObject.Find("explode");

        ps = obj.GetComponentInChildren<ParticleSystem>();

        obj.SetActive(false);
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            Instantiate(ps, Camera.main.ScreenToWorldPoint(mousePosition),
                Quaternion.identity);

                obj.SetActive(true);
                ps.Play();
        }
    }
}
