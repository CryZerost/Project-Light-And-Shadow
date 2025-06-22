using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool isRange = false;
    [SerializeField] bool isTurnOn;
    public GameObject lightSource;
    public GameObject darkSource;

    public SpriteRenderer mainSprite;
    public Sprite leftTrigger;
    public Sprite rightTrigger;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TriggerLamp();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            isRange = true;
            Debug.Log("dalam Area");
        }
    }

    public void TriggerLamp()
    {
        if (Input.GetKeyDown(KeyCode.E) && isRange)
        {
            isTurnOn = !isTurnOn;
            lightSource.SetActive(isTurnOn);
            darkSource.SetActive(!isTurnOn);

            if (isTurnOn)
            {
                mainSprite.sprite = leftTrigger;
            }
            else
            {
                mainSprite.sprite = rightTrigger;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRange = false;
            Debug.Log("keluar area");
        }
    }

   
}
