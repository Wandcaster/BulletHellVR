using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] GameObject start;
    public void Game()
    {
        start.SetActive(true);


    }
    public void Game(GameObject objToActivate)
    {
        objToActivate.SetActive(true);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Game();
    }

}
