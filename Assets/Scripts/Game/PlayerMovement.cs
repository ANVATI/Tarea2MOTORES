using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public KeyCode up;
    //public KeyCode down;
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    void Start()
    {
        SetMinMax();
        myRB = GetComponent<Rigidbody2D>();
        //if (up == KeyCode.None) up = KeyCode.UpArrow;
        //if (down == KeyCode.None) down = KeyCode.DownArrow;
    }

    void Update()
    {
        /*
        if (Input.GetKey(up) && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(down) && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }
        */
    }
    public void OnMovementUp(InputAction.CallbackContext context)
    {
        if(context.performed && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (context.canceled)
        {
            myRB.velocity = Vector2.zero;
        }
    }
    public void OnMovementDown(InputAction.CallbackContext context)
    {
        if (context.performed && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else if (context.canceled)
        {
            myRB.velocity = Vector2.zero;
        }
    }
    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
    }
}
