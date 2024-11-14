using UnityEngine;
using Live2D.Cubism.Core;  // Live2Dモデルのデータアクセス用

public class Live2DHitDetectionByObject_1 : MonoBehaviour
{
    // デフォーマー（当たり判定用）の名前リスト
    private string headColliderName = "HitAreaHead";
    private string handColliderName = "HitArea2";

    
    //アニメターの初期化
    private Animator m_Animator = null;

    // 球体オブジェクトのTransformを指定（Unity上でアタッチ）
    public Transform sphereObject;

    // 検出範囲（デフォーマーとの距離閾値）
    public float detectionRange = 0.5f;

    // Live2Dモデルのデフォーマー取得用
    private CubismDrawable headDrawable;
    private CubismDrawable handDrawable;

    void Start()
    {
        // Live2Dモデルのデフォーマーを取得
        var drawables = GetComponentsInChildren<CubismDrawable>();
        foreach (var drawable in drawables)
        {
            if (drawable.name == headColliderName)
                headDrawable = drawable;
            else if (drawable.name == handColliderName)
                handDrawable = drawable;
        }
        // アニメーター初期化処理
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 球体オブジェクトが設定されていれば距離をチェック
        if (sphereObject != null)
        {
            CheckCollisionWithDeformer(headDrawable, PerformHeadAction);
            CheckCollisionWithDeformer(handDrawable, PerformHandAction);
        }
    }

    // デフォーマーとの距離チェック
    private void CheckCollisionWithDeformer(CubismDrawable drawable, System.Action onHitAction)
    {
        if (drawable == null) return;

        // デフォーマーのワールド座標を取得
        Vector3 deformerPosition = drawable.transform.position;

        // 球体との距離を計算
        float distance = Vector3.Distance(deformerPosition, sphereObject.position);

        // 一定距離内に入ったらアクションを発動
        if (distance <= detectionRange)
        {
            onHitAction?.Invoke();
        }
    }

    // 頭に触れた場合のアクション（例: 表情変更）
    private void PerformHeadAction()
    {
        Debug.Log("頭に触れました！");
        // ここに頭のアクションを記述（例: 表情アニメーション）
        m_Animator.SetTrigger("talking");
    }

    // 手に触れた場合のアクション（例: 手を振る動き）
    private void PerformHandAction()
    {
        Debug.Log("手に触れました！");
        // ここに手のアクションを記述（例: アニメーション再生）
    }
}
