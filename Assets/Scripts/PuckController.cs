using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    private Vector2 startPosition;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
