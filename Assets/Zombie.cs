using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float tilt = 10f;
    public float acceleration = 10f;
    public float range = 2.5f;

    public AudioClip[] steps;

    Transform head;
    Transform root;
    NavMeshAgent ai;
    AudioSource source;

    void Start()
    {
        root = transform.Find("Root");
        head = transform.Find("Root/Head");
        ai = GetComponent<NavMeshAgent>();
        ai.SetDestination(Vector3.zero);
        source = GetComponent<AudioSource>();
        StartCoroutine("Walk");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < range)
        {
            Camera.main.SendMessage("ShowGameOver");
        }
    }

    void Footstep()
    {
        source.clip = steps[Random.Range(0, steps.Length)];
        source.Play();
    }

    IEnumerator Walk()
    {
        for (;;)
        {
            float velocity = 0f;
            Footstep();
            for (float rotate = -tilt; rotate < tilt; rotate += velocity * Time.deltaTime)
            {
                root.localRotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

            head.localRotation = Quaternion.Euler(0f, 0f, tilt);

            velocity = 0f;
            Footstep();
            for (float rotate = tilt; rotate > -tilt; rotate -= velocity * Time.deltaTime)
            {
                root.localRotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

            head.localRotation = Quaternion.Euler(0f, 0f, -tilt);
        }
    }
}
