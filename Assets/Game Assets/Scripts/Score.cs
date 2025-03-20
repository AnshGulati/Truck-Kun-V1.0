using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform DistanceCounter;
    public Text ScoreText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = (DistanceCounter.position.x - 21).ToString("0");
    }
}
