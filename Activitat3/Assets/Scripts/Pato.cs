using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pato : MonoBehaviour {

    public float velocidad, x_inicio, x_final;
    float paso;

    // Update is called once per frame
    void Update()
    {
        paso = velocidad * Time.deltaTime;
        transform.Translate(-Vector3.right * paso);
        if (x_inicio < x_final)
        {     
            if (transform.position.x >= x_final)
            {
                transform.position = new Vector3(x_inicio, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (transform.position.x <= x_final)
            {
                transform.position = new Vector3(x_inicio, transform.position.y, transform.position.z);
            }
        }
    }
}
