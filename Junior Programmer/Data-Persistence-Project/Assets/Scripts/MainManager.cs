using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text MainBestText;

    public GameObject GameOverText;

    public Text displayPlayerName;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    private int m_BestScore;
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        StartMenuUI.saveScript.FindGameManager();
        displayPlayerName.text = BestScoreText();
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        StartMenuUI.saveScript.LoadName();
        SaveBestScore();
        displayPlayerName.text = BestScoreText();

    }
    public void SaveBestScore()
    {
        if (m_Points >= LoadBestScore())
        {
            m_BestScore = m_Points;
            PlayerPrefs.SetInt("best score", m_BestScore);
            PlayerPrefs.SetString("best name", StartMenuUI.saveScript.playerName);
        }

    }
    public int LoadBestScore()
    {
        return PlayerPrefs.GetInt("best score");
    }
    public string LoadBestScoreName()
    {
        return PlayerPrefs.GetString("best name");
    }
    public string BestScoreText()
    {
        string bestScoreText = "Best Score : " + LoadBestScoreName() + " : " + LoadBestScore();
        return bestScoreText;
    }
}