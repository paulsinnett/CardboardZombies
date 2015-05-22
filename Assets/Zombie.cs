using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float tilt = 10f;
    public float acceleration = 10f;

    Transform head;

    void Start()
    {
        StartCoroutine("Walk");
        head = transform.Find("Root/Head");
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

            head.localRotation = Quaternion.Euler(0f, 0f, tilt);

            velocity = 0f;
            for (float rotate = tilt; rotate > -tilt; rotate -= velocity * Time.deltaTime)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

            head.localRotation = Quaternion.Euler(0f, 0f, -tilt);
        }
    }
}
