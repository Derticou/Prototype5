using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public GameObject buttons;
    public TextMeshProUGUI welcomeText;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty() {
        buttons.SetActive(false);
        welcomeText.gameObject.SetActive(false);
        gameManager.StartGame(difficulty);
    }
}
