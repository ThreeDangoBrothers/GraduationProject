using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book3 : MonoBehaviour
{
    public string targetObjectName = "food"; // 対象オブジェクトの名前
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    public float interactionThreshold = 1.0f; // 処理を行う閾値（例: 高さ）

    private GameObject targetObject;

    void Start()
    {
        // foodオブジェクトを探す
        targetObject = GameObject.Find(targetObjectName);
        if (targetObject == null)
        {
            Debug.LogError($"Object with name '{targetObjectName}' not found!");
        }
    }

    void Update()
    {
        if (targetObject == null) return; // 対象オブジェクトが見つからなければ処理しない

        // foodの現在の高さ（Y座標）を取得
        float currentYPosition = targetObject.transform.position.y;

        // 高さが閾値を超えたら回転を実行
        if (currentYPosition >= interactionThreshold)
        {
            Vector3 rotationVector = new Vector3(
                rotationSpeed.x * (reverse ? -1 : 1), 
                rotationSpeed.y * (reverse ? -1 : 1), 
                0
            );

            // foodオブジェクトを回転
            targetObject.transform.Rotate(rotationVector * Time.deltaTime);
        }
    }
}
