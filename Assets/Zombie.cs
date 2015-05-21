using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float tilt = 10f;
    public float acceleration = 10f;
    void Start()
    {
        StartCoroutine("Walk");
    }

    IEnumerator Walk()
    {
        for (;;)
        {
            float velocity = 0f;
            for (float rotate = -tilt; rotate < tilt; rotate += velocity * Time.deltaTime)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

            velocity = 0f;
            for (float rotate = tilt; rotate > -tilt; rotate -= velocity * Time.deltaTime)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }
            
            yield return null;
        }
    }
}
