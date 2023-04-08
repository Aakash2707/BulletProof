using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsScript : MonoBehaviour
{
    public List <GameObject> powerUps;
    public ScoreScript ss;
    public float waitTime, startWaitTime;
    public int rand, powerUpNo;
    bool test = false;
    public Vector2 spawnValues;
    public AudioSource PU;

    void Awake(){
        ss = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        PU = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ss.checkPoint > 0){
            if(!test){
                StartCoroutine(PowerUpsSpawn());
                test = true;
            }
        }
    }

    IEnumerator PowerUpsSpawn(){
        yield return new WaitForSeconds(startWaitTime);
        while(true){

            rand = UnityEngine.Random.Range(1,13);
            if(ss.checkPoint > 0 && ss.checkPoint <= 2){
                powerUpNo = 0;
            }
            else if(ss.checkPoint > 2 && ss.checkPoint <= 6){
                if(rand > 6){
                    powerUpNo = 0;
                }
                else{
                    powerUpNo = 1;
                }
            }
            else{
                if(rand <= 4){
                    powerUpNo = 0;
                }
                else if(rand >= 9){
                    powerUpNo = 1;
                }
                else{
                    powerUpNo = 2;
                }
            }
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            Instantiate(powerUps[powerUpNo],spawnPosition,transform.rotation);
            waitTime = UnityEngine.Random.Range(13,17);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void music(){
        PU.Play();
    }
}
