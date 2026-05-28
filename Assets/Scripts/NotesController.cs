using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    public float noteTime;
    public Vector2 goalPosition;
    RectTransform currentPosition;
    float noteSpeed;
    Vector2 direction;
    float currentTime;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        float passTime = noteTime + 2.0f;
        Invoke("DeleteButton", passTime);
        currentPosition = gameObject.GetComponent<RectTransform>();
        Vector2 startPosition = currentPosition.anchoredPosition;

        float distance = Vector2.Distance(startPosition, goalPosition);
        noteSpeed = distance / noteTime;

        direction = (goalPosition - currentPosition.anchoredPosition).normalized;

        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition.anchoredPosition += direction * noteSpeed * Time.deltaTime;
        currentTime += Time.deltaTime;
    }

    public void OnTapNote()
    {
        float timingError = Mathf.Abs(currentTime - noteTime);
        if (timingError < 0.5f)
        {
            gameManager.currentScore++;
        }
        DeleteButton();
    }
    void DeleteButton()
    {
        Destroy(this.gameObject);
    }
}
