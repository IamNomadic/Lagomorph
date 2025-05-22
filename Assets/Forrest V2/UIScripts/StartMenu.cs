using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip StartSFX;
    public AudioClip ButtonHover;
    public AudioClip ButtonPressed;
    public GameObject OptionsMenu;
    private void Start()
    {
    }
    public void OnPlayButton()
    {
        
        SceneManager.LoadScene("TheForrestV3");
    }

    public void OnHover()
    {
        Source.PlayOneShot(ButtonHover);
    }

    public void OnOptionsButton()
    {
        Source.PlayOneShot(ButtonPressed);
    }

    public void OnExitButton()
    {
        Source.PlayOneShot(ButtonPressed);
        StartCoroutine(ExitGame());
    }

    //functions
    private IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("TheForrestV3");
    }

    private IEnumerator OpenOptions()
    {
        yield return new WaitForSeconds(.1f);
        OptionsMenu.SetActive(true);
    }

    private IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("Exited Game");
        Application.Quit();
    }
}