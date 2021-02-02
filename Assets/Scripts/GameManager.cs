using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public SpawnScript spawner;
    //public ClockHand[] clockHands;
    public GameObject soundPrefab;
    public GameObject fxPrefab;

    float increaseSpeedTimer = 0.0f;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds time left to the game.
    /// </summary>
    /// <param name="amt">Amount to increase.</param>
    public void TimeIncrease(float amt)
    {
        timer.changeTime(amt);
    }
    public void TimeDecrease(float amt)
    {
        timer.changeTime(-amt);
    }

    public void NewCoin()
    {
        spawner.spawnNewCoin();
    }

    public void FX(Vector3 pos)
    {
        GameObject fxObj = (GameObject)Instantiate(fxPrefab, pos, Quaternion.identity);
        if (GameObject.Find("_fx")) { fxObj.transform.parent = GameObject.Find("_fx").transform; }
    }

    //******** SOUND

    public void PlaySingle(string soundName)
    {
        if (soundName == "") { return; }
        GameObject fxObj = (GameObject)Instantiate(soundPrefab, Vector3.zero, Quaternion.identity);
        if (GameObject.Find("_fx")) { fxObj.transform.parent = GameObject.Find("_fx").transform; }

        AudioSource asource = fxObj.GetComponent<AudioSource>();
        AudioClip a = (AudioClip)Resources.Load(soundName);
        asource.clip = a;
        fxObj.GetComponent<SelfDestruct>().duration = asource.clip.length;
        asource.spatialBlend = 0f;

        asource.volume = 0.4f;

        asource.Play();
    }
}
