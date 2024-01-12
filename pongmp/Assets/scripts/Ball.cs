using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float velx = 0.1f;
    float vely = 0;
    Vector3 pos;

    void Start()
    {
        pos = new Vector3(0, 0, -1);
    }

    void Update()
    {
        transform.position += new Vector3(pos.x + velx, pos.y + vely, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        velx *= (-1);
    }
}