using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // 移動速度の設定
    public float moveSpeed = 5f;

    void Update()
    {
        // 入力に基づいてXとYの移動量を計算
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 球体の新しい位置を計算
        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
