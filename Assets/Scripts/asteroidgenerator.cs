using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidgenerator : MonoBehaviour
{
    public GameObject[] asteroid;
    Vector3 pos = new Vector3(0f, 10f, 0f);
    Quaternion rot = Quaternion.Euler(0, 0, 0);
    int a_type;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generate(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator generate(float sec)
    {
        yield return new WaitForSeconds(sec);
        a_type = Random.Range(0, 4);
        asteroid[a_type].gameObject.SetActive(true);
        Instantiate(asteroid[a_type], pos, rot);
        sec = (sec > 0.8f) ? sec - 0.01f : 0.8f;
        StartCoroutine(generate(sec));
    }
}
