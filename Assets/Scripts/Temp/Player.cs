using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  

    [SerializeField] private TempGameplayManager _gm;
    [SerializeField] private GameObject explosionPrefab;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            Instantiate(explosionPrefab);

            _gm.GameEnded();
            Destroy(gameObject);
            return;
        }
    }
}
