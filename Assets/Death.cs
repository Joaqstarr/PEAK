using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Death : MonoBehaviour
{
    CanvasGroup _group;
    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
    }


    public void KillPlayer()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _group.alpha = 1;
        _group.interactable = true;
        _group.blocksRaycasts = true;
        Time.timeScale = 0;
        FadeToBlack._fading = true;
    }
    public void RestartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
        FadeToBlack._fading = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
