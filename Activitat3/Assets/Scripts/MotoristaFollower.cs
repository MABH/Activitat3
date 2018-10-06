using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoristaFollower : MonoBehaviour {
    public Transform motorista;
		
	// Update is called once per frame
	void Update () {
        transform.position = motorista.position - Vector3.forward * 10;
	}
}
