using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;

    //public GameObject[] targets2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);

        gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scoreText.text = "Score: " + score;
    }
}
