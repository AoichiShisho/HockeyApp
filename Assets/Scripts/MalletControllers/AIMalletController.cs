using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMalletController : MonoBehaviour
{
    public GameObject puck;
    private Rigidbody2D rb;
    private Rigidbody2D puckRb;
    private Vector2 targetPosition;
    private float speed = 30f;
    private float smoothTime = 0.1f;
    private Vector2 currentVelocity;

    public Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puckRb = puck.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        MoveAI();
    }

    void MoveAI()
    {
        Vector2 puckPosition = puck.transform.position;
        Vector2 puckVelocity = puckRb.velocity;

        float xTarget = CalculateXTarget(puckPosition, puckVelocity);
        float yTarget = CalculateYTarget(puckPosition.y);

        targetPosition = new Vector2(xTarget, yTarget);

        Vector2 newPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, speed);
        rb.MovePosition(newPosition);
    }
    
    float CalculateXTarget(Vector2 puckPosition, Vector2 puckVelocity)
    {
        float screenCenterX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
        float xTarget;

        if (puckVelocity.x > 0) {
            xTarget = Mathf.Max(puckPosition.x - 1f, transform.position.x);
        } else {
            xTarget = Mathf.Min(puckPosition.x + 1f, transform.position.x);
        }

        return Mathf.Max(xTarget, screenCenterX);
    }

    float CalculateYTarget(float puckY)
    {
        float screenTopY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // マレットが画面の上下の端を超えないようにY座標を制限
        return Mathf.Clamp(puckY, screenBottomY, screenTopY);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        Debug.Log( "ResetPosition");
    }
}
