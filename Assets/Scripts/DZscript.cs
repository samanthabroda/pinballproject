using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZscript : MonoBehaviour
{
    public GameObject newBall;
    private int balls = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Ball") && balls > 0)
        {
            Destroy(collision.gameObject);
            Instantiate(newBall);
            balls = balls - 1;
        } else if (balls == 0){
            Destroy(collision.gameObject);
        }
    }
}
