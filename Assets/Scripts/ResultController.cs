using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Text resultText;
    int currentScore;
    int clearScore;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();

        currentScore = gameManager.currentScore;
        clearScore = gameManager.clearScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore > clearScore)
        {
            resultText.text = "LIVE Success";
            resultText.text += "\n" + "Score : " + currentScore;
        }
        else
        {
            resultText.text = "LIVE Fail" + "\n" + "Score : " + currentScore;
        }
    }
}
