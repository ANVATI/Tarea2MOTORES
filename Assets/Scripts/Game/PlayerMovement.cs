using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    public Transform InitialPoint;
    [SerializeField] private float speed;
    private float limitSuperior;
    private float limitInferior;
    public TMP_Text Life;
    public TMP_Text Score;
    public int player_lives = 4;
    public PlayerData playerData;
    Vector2 _movement;
    private bool isInvulnerable = false;
    private Collider2D myCollider;

    void Start()
    {
        SetMinMax();
        myRB = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        playerData.ResetData();
    }

    void Update()
    {
        if (_movement.y > 0 && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (_movement.y < 0 && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }
        UpdateLife();
        UpdatePoints();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy" || other.tag == "Coffe" || other.tag == "Mushroom")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if (other.tag == "Obstacle")
        {
            if (!isInvulnerable)
            {
                ObstacleGenerator.instance.ManagerObstacle(other.gameObject.GetComponent<ObstacleController>(), this);
                transform.position = InitialPoint.position;
                StartCoroutine(Invulnerability());
            }
        }
    }

    IEnumerator Invulnerability()
    {
        myCollider.enabled = false;
        isInvulnerable = true;
        yield return new WaitForSeconds(1f);
        myCollider.enabled = true;
        isInvulnerable = false;
    }

    public void AddScore(int pointsToAdd)
    {
        playerData.SetScore(playerData.score + pointsToAdd);
    }

    private void UpdatePoints()
    {
        Score.text = "SCORE: " + playerData.score.ToString();
    }
    private void UpdateLife()
    {
        Life.text = "LIFE: " + player_lives.ToString();
    }
}