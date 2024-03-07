using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotion : MonoBehaviour
{
    public GameObject CarMotionCamera;
    public float speed=10f;

    public float nitro=25;
    public ScoreManager scoreManager;
    bool nitroActive=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Accelerate();
        MoveCar();
    }
    private void FixedUpdate()
    {
        if (scoreManager.score >= 50)
        {
            Nitro();
        }
    }
    void LateUpdate() {
        CarMotionCamera.transform.position = new Vector3(this.transform.position.x, 15, this.transform.position.z - 20f);

    }
    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 0.1f;
            speed = Mathf.Clamp(speed, 0f, 180f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= 0.1f;
            speed = Mathf.Clamp(speed, 0f, 180f);
        }
        
    }
    private void Nitro()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            nitroActive = true;
            nitro =240f;
            scoreManager.DecreaseScore(2);
            this.transform.Translate(Vector3.forward * nitro * Time.deltaTime);
            // Assuming you want to decrement 1 point every 5 milliseconds (0.005 seconds)
        }
    }

    void MoveCar(){
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(this.transform.position.x>20){
            speed -= 0.2f;
            speed = Mathf.Clamp(speed, 0f, 180f);
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime );
            transform.position = new Vector3(20f,transform.position.y,transform.position.z);
        }
        if(this.transform.position.x<-20){
            speed -= 0.2f;
            speed = Mathf.Clamp(speed, 0f, 180f);
            this.transform.Translate(Vector3.forward * speed *Time.deltaTime);
            transform.position = new Vector3(-20f,transform.position.y,transform.position.z);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0, 0);
        this.transform.Translate(horizontalMovement * 0.15f);
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("coin"))
        {
            scoreManager.IncreaseScore(10);
            Destroy(other.gameObject);

        }else if(other.gameObject.CompareTag("collision")){
            if(nitroActive)
            {
                scoreManager.score=50;
                nitroActive = false;

            }
            else
            {
                scoreManager.DecreaseScore(10);

            }
            StartCoroutine(SlowDown());
        }
    }
    private IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(0f);
        speed *= 0.7f;
        yield return new WaitForSeconds(0.2f);
        speed = 60f;
    }

}

