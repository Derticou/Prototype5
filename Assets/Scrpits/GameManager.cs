using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, livesText;
    public TextMeshProUGUI gameOverText;
    public Slider volumeSlider;
    public Button restartButton;
    public AudioSource music;
    public GameObject pauseScreen;

    public List<GameObject> targets;

    public bool isGameActive;
    public bool isGamePause;

    float spawnRate = 1.0f;
    int score;
    public int lives;

    
    

    // Start is called before the first frame update
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
        music.volume = volumeSlider.value;
    }
    public void StartGame(int difficulty)
    {

        isGamePause = true;
        isGameActive = true;
        spawnRate /= difficulty;
        lives = 3;
        livesText.text =lives.ToString();
        StartCoroutine("SpawnTarget");
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        //Pause Game
        if (isGameActive && Input.GetKeyDown(KeyCode.P))
        {
            pauseScreen.SetActive(true);
            isGameActive = false;
            Time.timeScale = 0;

        }
        //unpause Game
        else if (!isGameActive && Input.GetKeyDown(KeyCode.P))
        {
            pauseScreen.SetActive(false);
            isGameActive = true;
            Time.timeScale = 1;
        }

    }
    IEnumerator SpawnTarget() {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int intex = Random.Range(0, targets.Count);
            Instantiate(targets[intex]);
        }
    }
    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = score.ToString();

        if (score<0)
        {
            gameOver();
        }
    }
    public void gameOver() {
        if (lives>0) { lives--;}
        
        livesText.text = lives.ToString();
        if (lives<=0 || score<0)
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

    }
    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
    public void SetVolume() 
    {
        music.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("musicvolume", volumeSlider.value);
    }


}
