using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    private int numOfLives;



    public int getNumOfLives()
    {
        return numOfLives;
    }

    public void hasDied()
    {
        numOfLives--;
    }
}
