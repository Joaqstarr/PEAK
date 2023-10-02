using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    bool _paused = false;
    CanvasGroup _group;
    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
        _paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TryPause()
    {
        if (_paused) UnPause();
        else PauseGame();
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _group.alpha = 1;
        _group.blocksRaycasts = true;
        _group.interactable = true;

        _paused = true;
        Time.timeScale = 0;
        FadeToBlack._fading = true;
    }
    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _group.alpha = 0;
        _group.blocksRaycasts = false;
        _group.interactable = false;

        _paused = false;
        Time.timeScale = 1;
        FadeToBlack._fading = false;
    }
}
