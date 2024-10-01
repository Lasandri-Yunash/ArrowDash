/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class FirestoreManager : MonoBehaviour
{
    private FirebaseFirestore db;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;

            db = FirebaseFirestore.DefaultInstance;

            SaveData data = new SaveData();

            SaveDataToFirestore(data);
        });
    }

    private void SaveDataToFirestore(SaveData data)
    {
        db.Collection("users").AddAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data added successfully.");
            }
            else
            {
                Debug.LogError("Error adding data: " + task.Exception);
            }
        });
    }
}

[FirestoreData]
public class SaveData
{
    private string userName = "Silva"; // Default username
    private int test = 8890870; // Default test value

    [FirestoreProperty]
    public string UserName
    {
        get => userName; // Getter returns the private userName field
        set => userName = value; // Setter sets the private userName field
    }

    [FirestoreProperty]
    public int Test1
    {
        get => test; // Getter returns the private test field
        set => test = value; // Setter sets the private test field
    }

    [FirestoreProperty]
    public int Score
    {
        get => GameManager.Instance.HighScore;
        set => GameManager.Instance.HighScore = value;
    }
} */


/* -------------------------- GROUP ---------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class FirestoreManager : MonoBehaviour
{
    private FirebaseFirestore db;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;

            db = FirebaseFirestore.DefaultInstance;

            SaveData data = new SaveData();

            SaveDataToFirestore(data);
        });
    }

    private void SaveDataToFirestore(SaveData data)
    {
        db.Collection("users").AddAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data added successfully.");
            }
            else
            {
                Debug.LogError("Error adding data: " + task.Exception);
            }
        });
    }
}

[FirestoreData]
public class SaveData
{
    private string userName = "Silva"; // Default username
    private int test = 8890870; // Default test value

    [FirestoreProperty]
    public string UserName
    {
        get => userName; // Getter returns the private userName field
        set => userName = value; // Setter sets the private userName field
    }

    [FirestoreProperty]
    public int Test1
    {
        get => test; // Getter returns the private test field
        set => test = value; // Setter sets the private test field
    }

    [FirestoreProperty]
    public int Score
    {
        get => GameManager.Instance.HighScore;
        set => GameManager.Instance.HighScore = value;
    }
}
*/