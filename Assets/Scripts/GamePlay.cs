using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour
{
    public GameObject[]  monsters;
    public static GamePlay instance;
    public bool hasKey = false;
    public bool gameOver = false;
    public Text gameOverText;
    public Text keyMessage;
    public Text finishMessage;
    public Text keyStatus;
    public GameObject key;
    public GameObject door;
    public GameObject player;
    public float restartDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        keyMessage.gameObject.SetActive(false);
        finishMessage.gameObject.SetActive(false); 
        Debug.Log("Game Started.");

        keyStatus = GameObject.Find("KeyStatus").GetComponent<Text>();
    }

    void Awake(){
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey)
        {
            keyStatus.text = "Key found: Yes";
        }
        else{
            keyStatus.text = "Key found: No";
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Monster")){
            
            keyMessage.gameObject.SetActive(false);
            finishMessage.gameObject.SetActive(false); 
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Oh No! A monster caught you.";
            StartCoroutine(RestartGame());
            MonsterSound.sound_instance.PlaySound();
        }

         if(other.gameObject == key){
            gameOverText.gameObject.SetActive(false);
            finishMessage.gameObject.SetActive(false); 
            Destroy(key);
            hasKey = true;
            keyMessage.text = "You found the key!";
            keyMessage.gameObject.SetActive(true);
            keyStatus.text = "Key found: Yes";
            SoundController.sound_instance.PlaySound();
        }


        if(other.gameObject == door){
            
            if(hasKey == true){
                gameOverText.gameObject.SetActive(false);
                keyMessage.gameObject.SetActive(false);
                gameOver = true;
                finishMessage.text = "Well Done! You Escaped!";
                finishMessage.gameObject.SetActive(true);
                StartCoroutine(RestartGame());
                DoorSound.sound_instance.PlaySound();
            }
            else
            {
                finishMessage.text = "Get The Key";
                finishMessage.gameObject.SetActive(true);
            }
        }

        if(other.CompareTag("Player")){
            if(GamePlay.instance.hasKey){
                gameOverText.gameObject.SetActive(false);
                finishMessage.gameObject.SetActive(false); 
                Destroy(key);
                hasKey = true;
                keyMessage.text = "You found the key!";
            }
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
