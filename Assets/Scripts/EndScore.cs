using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public GameObject CurrentScore;
    public GameObject HighScore;
    private Text currentScoreText;
    private Text highScoreText;
    private int current;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText = CurrentScore.GetComponent<Text>();
        highScoreText = HighScore.GetComponent<Text>();

        currentScoreText.text = PlayerPrefs.GetString("CurrentScore");
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();

        current = System.Convert.ToInt32(currentScoreText.text);
        if (current > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", current);
            highScoreText.text = current.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "0";
    }
}
