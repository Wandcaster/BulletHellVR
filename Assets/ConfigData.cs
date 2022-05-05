using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigData
{
    public int cannonAmount;
    public float radius;
    public int queueLimit;
    public float minDelay;
    public float maxDelay;
    public int hp;

    public ConfigData(int cannonAmount, float radius, int queueLimit, float minDelay, float maxDelay, int hp)
    {
        this.cannonAmount = cannonAmount;
        this.radius = radius;
        this.queueLimit = queueLimit;
        this.minDelay = minDelay;
        this.maxDelay = maxDelay;
        this.hp = hp;



    }
}
