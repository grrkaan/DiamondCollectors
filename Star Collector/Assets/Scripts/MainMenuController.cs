using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{
    AudioSource sound;
    public AudioClip menuSound;
    public AudioClip menuClickSound;

    void Start() 
    {
        sound = GetComponent<AudioSource>();
        sound.clip = menuSound;
        sound.Play();
    }

    public void newGame() 
    {
        SceneManager.LoadScene("Level1");
        sound.clip = menuClickSound;
        sound.Play();
    }
    public void levels()
    {
        SceneManager.LoadScene("Levels");
        sound.clip = menuClickSound;
        sound.Play();
    }
    public void exitGame()
    {
        Application.Quit();
        sound.clip = menuClickSound;
        sound.Play();
    }
    //levels
    public void level1()
    {
        SceneManager.LoadScene("Level1");
        sound.clip = menuClickSound;
        sound.Play();   
    }
    public void level2()
    {
        SceneManager.LoadScene("Level2");
        sound.clip = menuClickSound;
        sound.Play();
    }
    public void level3()
    {
        SceneManager.LoadScene("Level3");
        sound.clip = menuClickSound;
        sound.Play();
    }
    public void level4()
    {
        SceneManager.LoadScene("Level4");
        sound.clip = menuClickSound;
        sound.Play();
    }

}
