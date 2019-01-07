using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TopCntrl : MonoBehaviour {

    Rigidbody phy;
    public int speed;
    int score = 0;
    public int starNum;
    public Text scoreText;
    public Text gameOverText;

    public AudioClip scoreSound;
    public AudioClip finishSound;
    public AudioClip gameOverSound;
    AudioSource sound;

	void Start () {
        phy = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
	}
	
	
	void FixedUpdate () 
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");
        Vector3 vec = new Vector3(yatay,jump,dikey);

        phy.AddForce(vec*speed);
        
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = "Score = " + score;
            sound.clip = scoreSound;
            sound.Play();
        }

        if(score == starNum)
        {
            gameOverText.text = "FINISHED";
            sound.clip = finishSound;
            sound.Play();
            StartCoroutine(nextLevel(gameOverText.text));
        }      
    }
    void OnCollisionEnter(Collision other) 
        {
    
        if(other.gameObject.tag == "Wall")
        {
            gameOverText.text = "GAME OVER";
            sound.clip = gameOverSound;
            sound.Play();
            StartCoroutine(gameOver(gameOverText.text));
        }
    
        }

    IEnumerator gameOver(string gameOverText) 
    {
        if(gameOverText == "GAME OVER")
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator nextLevel(string gameOverText) 
    {
        
        if(gameOverText == "FINISHED")
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Levels");
            
        }
        
            
    }
}
