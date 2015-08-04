using UnityEngine;
using System.Collections;

public class Horde : MonoBehaviour
{
    public Zombie zombie;
    public Texture[] faces;
    public float distance = 50f;

    void Start()
    {
        Score.score = 0;
        StartCoroutine(horde());
    }

    IEnumerator horde()
    {
        int timeToNext = 10;
        int zombies = 60;
        while (zombies > 0)
        {
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Vector3 position = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * distance;

            Zombie instance = Instantiate(zombie, position, Quaternion.identity) as Zombie;
            instance.BroadcastMessage("SetFace", faces[Random.Range(0, faces.Length)]);

            yield return new WaitForSeconds(timeToNext);

            if (timeToNext > 1)
            {
                timeToNext--;
            }

            zombies--;
        }

        Camera.main.SendMessage("ShowGameOver");
    }
}
