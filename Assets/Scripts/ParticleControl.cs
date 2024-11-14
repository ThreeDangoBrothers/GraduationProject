using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem particleSystem; // 操作するパーティクルシステム
    public float distanceFromCamera = 10f; // エフェクトが表示される距離（カメラからの距離）

    void Update()
    {
        // マウスの左ボタンが押されたらエフェクトを再生し、位置を更新
        if (Input.GetMouseButton(0)) // マウス左ボタンを押している間
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play(); // パーティクル再生
                Debug.Log("Particle system started."); // 再生状態をコンソールに表示
            }

            // マウス位置をワールド座標に変換
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distanceFromCamera; // カメラからの距離を設定
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // パーティクルシステムの位置をマウスのワールド座標に設定
            transform.position = worldPosition;
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop(); // マウスを離したらパーティクル停止
                Debug.Log("Particle system stopped."); // 停止状態をコンソールに表示
            }
        }
    }
}
