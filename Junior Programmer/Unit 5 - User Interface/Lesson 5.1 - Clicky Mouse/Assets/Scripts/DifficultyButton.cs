using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // We call this adding a listener,so that way it pays attention for when a certain event has happened.
        // Add a listener to your button, for the onClick event, and when the button is clicked,
        // it'll go into the SetDifficulty method, and it should trigger this message in your console.
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
