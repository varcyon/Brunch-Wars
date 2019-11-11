﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 150f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,rotateSpeed * Time.deltaTime);
    }

}
