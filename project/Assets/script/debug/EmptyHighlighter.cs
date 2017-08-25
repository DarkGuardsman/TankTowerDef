﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Debug script to render a dot on an empty object allowing it to be seen in the scene view
 */
public class EmptyHighlighter : MonoBehaviour {

    public Color color = Color.yellow;
    public float size = 0.1f;
    
	void OnDrawGizmos()
    {
       Gizmos.color = color;
       Gizmos.DrawSphere(transform.position, size);
    }
}