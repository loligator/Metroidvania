using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0f) {
            _rb.MovePosition(new Vector2(20f * Time.deltaTime, 0f));
        }

        if (Input.GetAxis("Horizontal") < 0f){
            _rb.MovePosition(new Vector2(20f * Time.deltaTime, 0f));
        }


	}
}
