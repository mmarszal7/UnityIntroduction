using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject GameLoseScreen;
    public GameObject GameWinScreen;

    public bool ShowScore = false;

    private bool gameOver = false;

    void Start()
    {
        FindObjectOfType<Player>().Won += () => OnGameOver(GameWinScreen);

        foreach (var enemy in FindObjectsOfType<Enemy>())
            enemy.SpottedPlayer += () => OnGameOver(GameLoseScreen);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnGameOver(GameObject gameOverScreen)
    {
        gameOver = true;
        gameOverScreen.SetActive(true);

        if (ShowScore)
        {
            var score = gameOverScreen.GetComponentsInChildren<Text>().First(c => c.name.Equals("Score"));
            score.text = Time.timeSinceLevelLoad.ToString("F2");
        }
    }
}
