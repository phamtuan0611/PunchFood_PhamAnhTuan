using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiffcultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDiffculty);
    }

    void SetDiffculty()
    {
        Debug.Log(button.gameObject + " was clicked");
        gameManager.StartGame(difficulty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
