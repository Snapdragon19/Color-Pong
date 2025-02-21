using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float minDirection = 0.5f;

    private bool stopped = false;

    private Vector3 direction;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //method of moving ball
        //transform.position += direction * speed * Time.deltaTime;
    }
    void FixedUpdate() 
    {
        if (this.stopped) 
        return;
    
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            
            newDirection.x = Mathf.Sin(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sin(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;
        }
    }
    private void ChooseDirection() {
        float sinX = Mathf.Sin(Random.Range(-1f, 1f));
        float sinZ = Mathf.Sin(Random.Range(-1f, 1f));

        this.direction = new Vector3(sinX, 0, sinZ);
    }
    public void Stop(){
        this.stopped = true;
    }
    public void Go() {
        ChooseDirection();
        this.stopped = false;
    }
}
