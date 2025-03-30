using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    float score = 0f;

    // Update is called once per frame

    void Start()
    {

        addScore(0f);
    }
    public void addScore(float scoreToAdd)
    {
        score += scoreToAdd;
        GetComponent<TMP_Text>().SetText("Score: "+score.ToString());
    }
    public float getScore()
    {
        return score;
    }
}
