using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] GameObject start;

    public void Game()
    {
        start.SetActive(true);
        //hideUI.SetActive(false);

    }
    public void Game(GameObject objToActivate)
    {
        objToActivate.SetActive(true);
        //hideUI.SetActive(false);


    }


    private void Update()
    {
//        if (Input.GetKeyDown(KeyCode.Z)) Game();
    }

}
