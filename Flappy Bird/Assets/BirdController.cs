using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BirdController : MonoBehaviour
{
    public float flyvelocity = 400f;
    private Rigidbody2D body;
    private Vector3 initPosition;
     private int score = 0;
     public GameObject scoreboard;
     private bool isPaused = false;
     public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
        scoreboard.SetActive(false);
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(startGame);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)|| Input.GetMouseButtonDown(0))
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, flyvelocity));
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Danger"){
            reset();
        }
    }
    void reset() {
        if (ScoreTrack.bestscore < score) {
            ScoreTrack.bestscore  = score;
        }
        Time.timeScale = 0f;
        scoreboard.SetActive(true);
        isPaused = true;
            GameObject.FindWithTag("cScore")
        .GetComponent<UnityEngine.UI.Text>().text = score + "";
        GameObject.FindWithTag("bScore")
        .GetComponent<UnityEngine.UI.Text>().text = ScoreTrack.bestscore  + "";
    }
    void startGame() {
        isPaused = false;
        Time.timeScale =1f;
        transform.position = initPosition;
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
    public void updateScore(int amount) {
        score += amount;
        GameObject.FindWithTag("ScoreText")
            .GetComponent<UnityEngine.UI.Text>().text = score + "";
    }
    
}

public class ScoreTrack
{
    public static int bestscore = 0;
}