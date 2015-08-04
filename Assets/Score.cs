using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    static public int score = 0;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = string.Format("Score: {0}", score);
    }
}
