using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletController : MonoBehaviour
{
    public bool isLeftMallet; 
    private float speed = 30f;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private float smoothTime = 0.1f;
    private Vector2 currentVelocity;

    public Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer) {
            if (Input.GetMouseButton(0)) {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        } else {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }

        // 画面の中央のX座標を取得
        float screenCenterX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;

        // マレットの移動範囲を制限
        if (!isLeftMallet) {
            targetPosition.x = Mathf.Min(targetPosition.x, screenCenterX);
        } else {
            targetPosition.x = Mathf.Max(targetPosition.x, screenCenterX);
        }

        // 画面の上下の範囲を制限
        float screenTopY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        targetPosition.y = Mathf.Clamp(targetPosition.y, screenBottomY + 1.5f, screenTopY - 1.5f);

        // 新しい位置を計算して移動
        Vector2 newPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, speed);
        rb.MovePosition(newPosition);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        Debug.Log( "ResetPosition");
    }
}
