using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidbehave : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public AudioSource destroysound;
    float speedx;
    public float speed = 5f;
    ParticleSystem explode;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //speedx = Player.transform.position.x;
        explode = this.transform.GetChild(0).GetComponent<ParticleSystem>();
        destroysound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        speedx = Player.transform.position.x - this.transform.position.x;
        if (speedx < 0 && speedx < (speed - 1) * (-1))
        {
            speedx = (speed - 1) * (-1);
        }
        else if (speedx > 0 && speedx > (speed - 1))
        {
            speedx = speed - 1;
        }
        this.transform.position += new Vector3(speedx, speed * -1, 0f) * Time.deltaTime;
        this.transform.Rotate(Vector3.forward * -100 * Time.deltaTime);
        if (this.transform.position.y < -10)
        {
            Player.GetComponent<playercontrol>().score++;
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player.GetComponent<playercontrol>().score++;
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        explode.Play();
        destroysound.Play();
        speed = 0;
        speedx = 0;
        StartCoroutine(Explode());
    }

    

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
