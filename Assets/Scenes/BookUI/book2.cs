using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book2 : MonoBehaviour
{
    public GameObject targetObject; // 回転させるオブジェクト
    public Vector2 rotationSpeed = new Vector2(10f, 20f); // 回転速度を大きく設定
    public bool reverse; // 回転方向の反転
    [SerializeField] private GameObject target; // 座標変化を追跡するターゲット

    private Vector3 previousPosition; // 前回の座標
    private bool isFoodActive; // foodがアクティブかどうか

    void Start()
    {
        target = GameObject.Find("food"); // ターゲットを取得
        if (target != null)
        {
            previousPosition = target.transform.position;
            isFoodActive = target.activeSelf;
        }
        else
        {
            Debug.LogError("ターゲットオブジェクトが見つかりません。");
        }

        if (targetObject == null)
        {
            Debug.LogError("Target Objectが設定されていません。");
        }
    }

    void Update()
    {
        if (target == null || targetObject == null) return;

        // foodがアクティブかをチェック
        bool currentFoodActive = target.activeSelf;

        // foodが消えた場合、計算をリセット
        if (!currentFoodActive && isFoodActive)
        {
            Debug.Log("Foodが消えました。位置変化をリセットします。");
            previousPosition = Vector3.zero; // 座標変化の計算をリセット
            isFoodActive = false;
            return;
        }

        // foodが再び出現した場合、位置を初期化
        if (currentFoodActive && !isFoodActive)
        {
            Debug.Log("Foodが再び出現しました。初期位置を設定します。");
            previousPosition = target.transform.position; // 新しい初期位置を設定
            isFoodActive = true;
            return;
        }

        if (!currentFoodActive) return;

        // 現在のターゲット位置
        Vector3 currentPosition = target.transform.position;

        // 座標変化量を計算
        Vector3 deltaPosition = (currentPosition - previousPosition) * 10f; // 倍率を調整
        Debug.Log($"Delta Position: {deltaPosition}");

        // 微小な動きの場合は無視
        if (deltaPosition.magnitude < 0.01f) return;

        // 回転計算
        Vector3 newAngle = Vector3.zero;
        if (!reverse)
        {
            newAngle.x = deltaPosition.y * rotationSpeed.x;
            newAngle.y = deltaPosition.x * rotationSpeed.y;
        }
        else
        {
            newAngle.x = deltaPosition.y * rotationSpeed.x;
            newAngle.y = deltaPosition.x * rotationSpeed.y;
        }
        Debug.Log($"New Angle: {newAngle}");

        // 回転を適用
        targetObject.transform.Rotate(newAngle);

        // 前回の座標を更新
        previousPosition = currentPosition;
        Debug.Log($"Previous Position: {previousPosition}");
        Debug.Log($"Current Position: {currentPosition}");
    }
}
