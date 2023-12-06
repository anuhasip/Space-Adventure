using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontrol : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject canvas;
    public GameObject bullet;
    private float fspeed = 5f;
    
    public int lives;
    public int bullets;
    public int score;
    public bool right = false;
    public bool left = false;
    


    public AudioSource shootsound;

   
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        bullets = 3;
        canvas.GetComponent<uimanager>().lifecount(lives);
        StartCoroutine(BulletGenerate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (right == true && player.transform.position.x < 7f)
        {
            player.transform.position += new Vector3(fspeed, 0f, 0f) * Time.deltaTime;
        }
        if (left == true && player.transform.position.x > -7f)
        {
            player.transform.position += new Vector3(-fspeed, 0f, 0f) * Time.deltaTime;
        } 
        
    }
    public void moveright()
    {
        right = true;
    }
    public void stopright()
    {
        right = false;
    }
    public void moveleft()
    {
        left = true;
    }
    public void stopleft()
    {
        left = false;
    }
    public void shoot()
    {
        if (bullets > 0)
        {
            shootsound.Play();
            Vector3 pos = this.transform.position;
            pos.y = -0.9f;
            Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
            bullets--;
            canvas.GetComponent<uimanager>().bulletcount(bullets);
        }
    }


    IEnumerator BulletGenerate()
    {
        yield return new WaitForSeconds(5f);
        if (bullets < 3)
        {
            bullets++;
            canvas.GetComponent<uimanager>().bulletcount(bullets);
        }
        StartCoroutine(BulletGenerate());
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        lives--;
        canvas.GetComponent<uimanager>().lifecount(lives);
        if (lives <= 0)
        {
            gameOver();
        }
    }
    
    private void gameOver()
    {
        canvas.GetComponent<uimanager>().gameOver();
        this.transform.GetChild(0).gameObject.transform.GetComponent<ParticleSystem>().Play();
        this.transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    

}
