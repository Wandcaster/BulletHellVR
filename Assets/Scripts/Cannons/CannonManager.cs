using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CannonManager : MonoBehaviour
{
    [Tooltip("Iloœæ dzia³ do utworzenia")]
    [SerializeField] int cannonToSpawn;
    [Tooltip("Promieñ od gameObject w jakim ma utworzyæ dzia³a")]
    [SerializeField] float radius;
    [Tooltip("Iloœæ pocisków w kolejce o losowej czêstotliwoœci")] 
    [SerializeField] int QueueLimit;
    [Tooltip("Minimalny czas po którym pocisk mo¿e wystrzeliæ")]
    [SerializeField] float minDelay;
    [Tooltip("Maksymalny czas po którym pocisk mo¿e wystrzeliæ")]
    [SerializeField] float maxDelay;
    [Tooltip("Iloœæ ¿yæ")]
    [SerializeField] uint hp;

    private int currentBullets;
    private GameObject cannonFolder;
    private GameObject bullet;

    private DateTime timeStart;
    private System.Random rand;
    private bool[] freeCannon;




    [SerializeField] private GameObject targetFolder;
    private int targetPoints;

    //TODO: zoptymalizuj, usun resp 2 kul w tym samym miejscu
    private GameObject ChooseRandomCannon() {
        int id;
        while (true)
        {
            id = rand.Next(cannonToSpawn);
            //if (freeCannon[id])
            {
                GameObject cannon = cannonFolder.transform.Find("Cannon" + id).gameObject;
                //freeCannon[id] = false;
                return cannon;
            }
        }
    }


    //TODO: obracanie po osi Y gameObject'u Cannons
    //TODO: Player.instance.gameObject.transform zwraca pozycje stop, celowanie powinno byc zalezne od jego wysokosci
    private void FixedUpdate()
    {
        //Debug.Log(currentBullets);
        if (currentBullets< QueueLimit) {
            currentBullets++;
            StartCoroutine(ShotPlayer(GenerateDelay(), Player.instance.transform, 100, GetCannonBulletSpawnPoint(ChooseRandomCannon())));
            
        }
    }

    private Vector3 GetCannonBulletSpawnPoint(GameObject gameObject)
    {
        //Debug.Log(gameObject.transform.Find("BulletSpawnPosition").position);
        return gameObject.transform.Find("BulletSpawnPosition").position;
    }

    private float GenerateDelay()
    {
        return UnityEngine.Random.Range(minDelay, maxDelay);
    }

    private void Awake()
    {
        cannonFolder = gameObject.transform.Find("Cannons").gameObject;
        bullet = gameObject.transform.Find("Bullet").gameObject;
        freeCannon = new bool[QueueLimit];
        for(int i = 0; i < QueueLimit; i++)
        {
            freeCannon[i] = true;
        }
      
        targetPoints = targetFolder.transform.childCount;
        if (hp == 0) hp = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        timeStart = DateTime.UtcNow;
        rand = new System.Random();
        SpawnCannons(cannonToSpawn, radius);

    }
    private void SpawnCannons(int amountToSpawn, float r)
    {
        GameObject cannon = gameObject.transform.Find("Presets").Find("Cannon0").gameObject;
        for (int i = 0; i < amountToSpawn; i++)
        {
            float angle = i * Mathf.PI * 2f / amountToSpawn;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * r, gameObject.transform.position.y+0.25f, Mathf.Sin(angle) * r);
            GameObject go = Instantiate(cannon, newPos, Quaternion.identity);
            go.name = "Cannon" + i;
            go.transform.SetParent(cannonFolder.transform);
            go.SetActive(true);
        }
    }
    IEnumerator ShotPlayer(float delay, Transform playerPosition, float force, Vector3 spawnPos)
    {
        //Debug.Log("ShotPlayer");

        Transform target = targetFolder.transform.Find("TargetPoint"+rand.Next(targetPoints));
//        Debug.Log();


        yield return new WaitForSeconds(delay);
        GameObject tmp = Instantiate(bullet, spawnPos, Quaternion.identity);
        tmp.GetComponent<Shot>().hit += DmgTaken;
        tmp.SetActive(true);
        tmp.GetComponent<Shot>().Shoot(target);




        currentBullets--;
        //Debug.Log("Bang");

        yield return new WaitForSeconds(10);

        tmp.GetComponent<Shot>().hit -= DmgTaken;

        Destroy(tmp,10);

    }

    private void DmgTaken()
    {
        hp--;
        if (hp == 0) GameOver();
    }

    private void GameOver()
    {
        TimeSpan time = DateTime.UtcNow - timeStart;
        double score = time.TotalSeconds * 2 / 7;
        Debug.Log("wynik:" + score);


        throw new NotImplementedException();
    }
}
