using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SceneChanger : MonoBehaviour
{
    public GameObject AudioImage;
    public Sprite MutedSprite;
    public Sprite AudioSprite;
    
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void exitGame() {
        Application.Quit();
    }

    public void muteToggle(bool muted)
    {

        if (muted)
        {
            AudioListener.volume = 0;
            AudioImage.GetComponentInChildren<Image>().sprite = MutedSprite;
        }
        else
        {
            AudioListener.volume = 1;
            AudioImage.GetComponent<Image>().sprite = AudioSprite;
        }
    }
}