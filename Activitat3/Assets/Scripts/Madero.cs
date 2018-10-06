using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madero : MonoBehaviour {
    public float velocidad=10;
    float paso;
    
	// Update is called once per frame
	void Update () {
        paso = velocidad * Time.deltaTime;
        transform.position += Vector3.right * paso;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag.CompareTo("Piedra") == 0)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            velocidad = -velocidad;
        }
    }
}
