﻿using UnityEngine;
using System.Collections;

public class Camera_Bilborard : MonoBehaviour {

	// Use this for initialization
	public Camera m_Camera;
 
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
