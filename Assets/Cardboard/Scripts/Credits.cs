using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour
{
    ScrollRect credits;
    float time;

    void Start()
    {
        credits = GetComponent<ScrollRect>();
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        credits.verticalNormalizedPosition = Mathf.Clamp01(1 - time);
    }
}
