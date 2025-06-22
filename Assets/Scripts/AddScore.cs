using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public ScoreManager scoremanager;
    public int pointscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if  (other.CompareTag("Player"))
        {
            scoremanager.AddScore(pointscore);
            this.gameObject.SetActive(false);
        }
    }
}
