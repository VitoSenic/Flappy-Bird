﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * 4f * Time.deltaTime);
    }
}
