using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float killCount;
    public Text killCountText;
    public GameObject pauseMenuUI;
    public GameObject winLevelUI;
    private bool gameIsPaused = false;  
   
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void WinLevel()
    {
        winLevelUI.SetActive(true);
        killCountText.text = killCount + " Alien Destroyed"; 
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void AppQuit()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
        public void AddKill()
    {
        killCount++;
        killCountText.text = "Alien Again:: " + killCount;
    }
}
