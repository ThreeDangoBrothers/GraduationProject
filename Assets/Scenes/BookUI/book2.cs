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

    void Start()
    {
        target = GameObject.Find("food"); // ターゲットを取得
        if (target != null)
        {
            previousPosition = target.transform.position;
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

        // 現在のターゲット位置
        Vector3 currentPosition = target.transform.position;

        // 座標変化量を計算
        Vector3 deltaPosition = (currentPosition - previousPosition) * 50f; // 倍率を調整
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
            newAngle.x = -deltaPosition.y * rotationSpeed.x;
            newAngle.y = -deltaPosition.x * rotationSpeed.y;
        }
        Debug.Log($"New Angle: {newAngle}");

        // 回転を適用
        targetObject.transform.Rotate(newAngle);

        // 前回の座標を更新
        previousPosition = currentPosition;
    }
}
