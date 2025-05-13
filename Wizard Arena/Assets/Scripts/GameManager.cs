
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    private int enemiesRemaining;
    public GameObject messagePanel;  // UI panel to display the message
    public TextMeshProUGUI messageText;         // Text component to display the message

    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    public void EnemyDefeated()
    {
        enemiesRemaining--;
        if (enemiesRemaining < 0)
            enemiesRemaining = 0;
    }

    public bool AllEnemiesDefeated()
    {
        return enemiesRemaining <= 0;
    }
    void Update()
    {
        // If the game is paused and any arrow key is pressed, resume the game
        if (isGamePaused && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                             Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            ResumeGame();
        }
    }
    public void PauseGame(string message)
    {
        isGamePaused = true;
        Time.timeScale = 0f;  // Pauses the game (freezes all physics and time-related processes)
        messageText.text = message;
        messagePanel.SetActive(true);  // Show the message panel
    }
    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;  // Resumes the game (restores normal time flow)
        messagePanel.SetActive(false);  // Hide the message panel
    }
}
