using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elimination : MonoBehaviour
{
    public GameObject eliminatedUI;
    public GameObject victoryUI;
    int counter = 0;
    int number;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        number = gos.Length;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" )
        {
            Destroy(col.gameObject);
            counter++;
            if (counter == number)
                Victory();
        }
        if(col.gameObject.tag == "Player" )
        {

            Time.timeScale = 0;
            print("YOU LOST");
            eliminatedUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Lose");

        }
    }

    private void Victory()
    {
        Time.timeScale = 0;
        print("YOU WON");
        victoryUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Victory");

    }
}
