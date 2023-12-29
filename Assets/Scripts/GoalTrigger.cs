using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puck")) {
            Debug.Log("Goal Triggered: " + gameObject.name);
            
            if (gameObject.name == "Goal1") {
                gameController.GoalScored(2);
            } else if (gameObject.name == "Goal2") {
                gameController.GoalScored(1);
            }
        }
    }
}
