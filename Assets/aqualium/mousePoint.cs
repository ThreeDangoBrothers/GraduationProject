using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 objPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//エサが追尾する
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = objPosition;
        }
        // if(Input.GetMouseButtonUp(0)){
        //     objPosition = Camera.main.ScreenToWorldPoint(mousePosition-100);//クリック離したら消えるor画面外に飛ばす処理
        // }
    }
}