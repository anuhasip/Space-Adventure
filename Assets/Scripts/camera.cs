using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{

    public GameObject objectToFollow;

    public float speed = 100.0f;

    void FixedUpdate()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y+1.5f, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
    }
}