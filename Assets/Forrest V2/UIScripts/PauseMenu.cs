using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject OptionsMenu;
    public AudioSource Source;
    public AudioClip ButtonHover;
    public AudioClip ButtonPressed;

    public void Pause()
    {
        if(GameIsPaused)
        {
            ResumeGame();
        }
        else
            PauseGame();
    }

    public void ResumeGame()
    {
        
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void PauseGame()
    {
        
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void OnHover()
    {
        Source.PlayOneShot(ButtonHover);
    }
    public void OnPlayButton()
    {
        Source.PlayOneShot(ButtonPressed);
        ResumeGame();
    }
    public void OnRestartButton()
    {
        Source.PlayOneShot(ButtonPressed);
        StartCoroutine(RestartGame());
    }
    public void OnOptionsButton()
    {
        Source.PlayOneShot(ButtonPressed);
        StartCoroutine(OpenOptions());
    }
    public void OnExitButton()
    {
        Source.PlayOneShot(ButtonPressed);
        ExitGame();
    }
    public void OnDeathExit()
    {
        Source.PlayOneShot(ButtonPressed);
        StartCoroutine(ReturnToTitle());
    }
    
    void ExitGame()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);

    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator OpenOptions()
    {
        yield return new WaitForSeconds(0f);
        OptionsMenu.SetActive(true);
    }
    IEnumerator ReturnToTitle()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("Title");
    }
}