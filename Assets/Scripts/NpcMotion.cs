using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMotion : MonoBehaviour
{
    // Start is called before the first frame update
    public CarMotion Mycar;
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomS = Random.Range(-20f, 30f);
        speed = Mycar.speed + randomS;
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
