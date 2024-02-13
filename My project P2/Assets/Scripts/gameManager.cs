using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Global Vars")]
    public GameObject myPlayer;
    public float timer;
    public int score;
    public float timeLimit;

    [Header("NPC Vars")]
    public GameObject collectible1;
    public float spawnInterval;
    public float spawnTimer;
    public Vector2 spawnXBounds;
    public Vector2 spawnYBounds;

    public TextMeshProUGUI TitleText;

    

    public enum GameState
    {
        GAMESTART, PLAYING, GAMEOVER
    }

    public GameState myGameState;
    
    // Start is called before the first frame update
    void Start()
    {
        myGameState = GameState.GAMESTART;
        myPlayer.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (myGameState)
        {
            case GameState.GAMESTART:
                if(Input.GetKey(KeyCode.Space))
                {
                    EnterPlaying();
                }
                break;

            case GameState.PLAYING:

                timer += Time.deltaTime;
                spawnTimer += Time.deltaTime;

                if (timer > timeLimit)
                {
                   EnterFinale();
                }

                float x = Random.Range(spawnXBounds.x, spawnXBounds.y);
                float y = Random.Range(spawnYBounds.x, spawnYBounds.y);
                Vector2 targetPos = new Vector2(x, y);

                if (spawnTimer > spawnInterval)
                {
                    GameObject newenemy = Instantiate(collectible1, targetPos, Quaternion.identity);
                    EnemyControl myControl = newenemy.GetComponent<EnemyControl>();
                    myControl.myPlayer = myPlayer;
                    spawnTimer = 0;

                    
                }

                break;

            case GameState.GAMEOVER:

                if (Input.GetKey(KeyCode.Space))
                {
                    EnterPlaying();
                }

                break;
                      
        }
    }

    void EnterPlaying()
    {
        timer = 0;
        myGameState = GameState.PLAYING;
        myPlayer.SetActive(true);
        TitleText.enabled = false;
    }

    void EnterFinale()
    {
        myGameState = GameState.GAMEOVER;
        myPlayer.SetActive(false);
        TitleText.enabled = true;
        TitleText.text = "Congrats, You Survived!";


        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            Destroy(gameObj);
        }

    }

   
}
