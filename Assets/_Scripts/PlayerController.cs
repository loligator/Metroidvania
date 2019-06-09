using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Components
    Rigidbody2D _rb;
    BoxCollider2D _collider;

    //Serialized Parameters
    [SerializeField]
    private float GravityScale = 1f;
    [SerializeField]
    private float TerminalVelocity = 53f;
    [SerializeField]
    private float WalkSpeed = 10f;
    [SerializeField]
    private float GroundCheckResolution = 5f;

    //Movement Vars
    float horz = 0f;
    bool moveRight = false;
    bool moveLeft = false;
    bool jump = true;

    //Lingering Forces
    float gravityForce = 0f;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Collect User Input
        horz = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        if (horz > 0f) {
            moveRight = true;
        } else {
            moveRight = false;
        }

        if (horz < 0f) {
            moveLeft = true;
        } else {
            moveLeft = false;
        }
    }

    private void FixedUpdate() {
        Vector2 newPos = _rb.position;

        Vector3 colliderBounds = _collider.bounds.extents;
        Vector2 bottomLeft = new Vector2(transform.position.x - colliderBounds.x, transform.position.y - colliderBounds.y);
        float stepLength = _collider.bounds.size.x / GroundCheckResolution;
        //Calculate Grounded
        for(int i = 0; i < GroundCheckResolution; i++) {
            Physics2D.Raycast(bottomLeft + new Vector2(0, stepLength * i), Vector2.down);
            Debug.DrawRay(bottomLeft + new Vector2(0, stepLength * i), Vector2.down, Color.red);
        }

        //Calculate Gravity
        //GravityScale
        if (gravityForce < TerminalVelocity) {
            gravityForce -= Mathf.Min(GravityScale * 9.8f, TerminalVelocity);
        }

        //Other Forces?

        //Calculate Player Movement
        //Left/Right
        if (moveRight) {
            newPos += new Vector2(WalkSpeed * Time.deltaTime, 0f);
        }

        if (moveLeft) {
            newPos += new Vector2(-WalkSpeed * Time.deltaTime, 0f);
            //_rb.MovePosition(new Vector2(-10f * Time.deltaTime, 0f) + _rb.position);
        }
        //Jump

        //newPos -= new Vector2(0f, gravityForce);
        _rb.MovePosition(newPos);
    }
}
