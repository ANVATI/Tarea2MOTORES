using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleGenerator : MonoBehaviour
{
    public static ObstacleGenerator instance;
    public List<GameObject> Obstacles = new List<GameObject>();
    public GameObject Warning;
    private float time_to_create = 6f;
    private float limitSuperior;
    private float limitInferior;
    [SerializeField] private AudioSource audioCollision;
    [SerializeField] private AudioSource audioHeart;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    void Start()
    {
        SetMinMax();
        StartCoroutine(GenerateObstaclesWithWarning());
    }

    IEnumerator GenerateObstaclesWithWarning()
    {
        while (true)
        {
            GameObject _obstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            _obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);

            GameObject _warningSign = Instantiate(Warning, new Vector3(transform.position.x -5, _obstacle.transform.position.y, 0f), Quaternion.identity);

            yield return new WaitForSeconds(2f);
            Destroy(_warningSign);

            yield return new WaitForSeconds(time_to_create - 2f);
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    public void ManagerObstacle(ObstacleController obstacle_script, PlayerMovement player_script = null)
    {
        if (player_script == null)
        {
            Destroy(obstacle_script.gameObject);
            return;
        }

        int lives = player_script.player_lives;
        int live_changer = obstacle_script.obstacles.lifeChange;
        lives += live_changer;
        print(lives);

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        player_script.player_lives = lives;
        Destroy(obstacle_script.gameObject);
        audioCollision.Play();
        audioHeart.Play();
    }
}