/*using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public FirebaseFirestore Firestore;
    private float saveInterval = 60f; // Time interval in seconds for auto-saving
    private float nextSaveTime;

    private void Awake()
    {
        Firestore = FirebaseFirestore.DefaultInstance;
    }

    private void Start()
    {
        nextSaveTime = Time.time + saveInterval;
    }

    private void Update()
    {
        // Check if it's time to save
        if (Time.time >= nextSaveTime)
        {
            SaveToCloud();
            nextSaveTime = Time.time + saveInterval;
        }
    }

    public void SaveToCloud()
    {
        SaveData saveData = new SaveData();
        Firestore.Document("save_data/2").SetAsync(saveData);
    }


}
*/




/*

private void Start()
    {
        LeftHoop.SetActive(true);
        RightHoop.SetActive(false);

        gameplayManager = FindObjectOfType<TempGameplayManager>();
        if (gameplayManager != null)
        {
            score = gameplayManager.GetScore();
        }
        ScoreText.text = score.ToString();
    }

    public void PlayerScored()
    {
        score += 1;
        ScoreText.text = score.ToString();

        if (gameplayManager != null)
        {
            gameplayManager.UpdateScore(score);
        }

        ChangeDirection();
    } 
 

 */