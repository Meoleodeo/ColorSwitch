using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
