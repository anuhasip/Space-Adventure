using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    public GameObject startui;
    public GameObject gameui;
    public GameObject pauseui;
    public GameObject finishui;
    public GameObject player;
    public GameObject[] lifecounts;
    public GameObject[] bulletcounts;

    public Text scoretxt;
    public Text yourscore;
    public Text highscore;


    private void Start()
    {
        Time.timeScale = 0;

    }
    void FixedUpdate()
    {

        scoretxt.text = player.GetComponent<playercontrol>().score + "";
        
    }
    
    
    public void lifecount(int i)
    {
        if (i == 0)
        {
            lifecounts[0].SetActive(false);
            lifecounts[1].SetActive(false);
            lifecounts[2].SetActive(false);
        }
        if (i == 1)
        {
            lifecounts[0].SetActive(true);
            lifecounts[1].SetActive(false);
            lifecounts[2].SetActive(false);
        }
        if (i == 2)
        {
            lifecounts[0].SetActive(true);
            lifecounts[1].SetActive(true);
            lifecounts[2].SetActive(false);
        }
        if (i == 3)
        {
            lifecounts[0].SetActive(true);
            lifecounts[1].SetActive(true);
            lifecounts[2].SetActive(true);
        }
        
    }

    public void bulletcount(int i)
    {
        if (i == 0)
        {
            bulletcounts[0].SetActive(false);
            bulletcounts[1].SetActive(false);
            bulletcounts[2].SetActive(false);
        }
        if (i == 1)
        {
            bulletcounts[0].SetActive(true);
            bulletcounts[1].SetActive(false);
            bulletcounts[2].SetActive(false);
        }
        if (i == 2)
        {
            bulletcounts[0].SetActive(true);
            bulletcounts[1].SetActive(true);
            bulletcounts[2].SetActive(false);
        }
        if (i == 3)
        {
            bulletcounts[0].SetActive(true);
            bulletcounts[1].SetActive(true);
            bulletcounts[2].SetActive(true);
        }

    }

    public void play()
    {
        gameui.SetActive(true);
        startui.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause()
    {
        Time.timeScale = 0;
        pauseui.SetActive(true);
        gameui.SetActive(false);
    }
    public void resume()
    {
        pauseui.SetActive(false);
        gameui.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameOver()
    {
        gameui.SetActive(false);
        yourscore.text = "YOUR SCORE : " + player.GetComponent<playercontrol>().score;
        if (player.GetComponent<playercontrol>().score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", player.GetComponent<playercontrol>().score);
        }
        highscore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highscore");
        StartCoroutine(waittoquit());
    }

    IEnumerator waittoquit()
    {
        yield return new WaitForSeconds(1f);
        finishui.SetActive(true);
        Time.timeScale = 0;
    }
}
