using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOver;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI winner;
    public ParticleSystem explosionParticle;
    void Start()
    {
        // isGameActive = true;
        // score = 0;
        // StartCoroutine(nameof(SpawnTarget));
        // UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    public void GameOver()
    {
        if (score < 0)
        {
            restartButton.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            isGameActive = false;
        }
        // restartButton.gameObject.SetActive(true);
        // gameOver.gameObject.SetActive(true);
        // isGameActive = false;
    }

    public void Winner()
    {
        if (score >= 30)
        {
            restartButton.gameObject.SetActive(true);
            winner.gameObject.SetActive(true);
            //Instantiate(explosionParticle, winner.rectTransform.position, winner.rectTransform.rotation).Play();
            isGameActive = false;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
    }
}