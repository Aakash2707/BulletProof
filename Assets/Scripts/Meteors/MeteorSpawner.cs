using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public List <GameObject> meteor;
    public Vector2 spawnValues;
    public int meteorCount;
    public int meteorNo;
    public int difficulty;
    public float spawnWaitTime, startWaitTime, waveWaitTime, meteorSpeed, originalSpeed;
    public int meteor2Probabilty, meteor3Probabilty;
    public int rand, rand2;
    public float rand3;
    bool test1, test2, test3, test4, test5;
    public ScoreScript ss;

    void Awake(){
        ss = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }
    void Start()
    {
        StartCoroutine(SpawnMeteors());
        meteorCount = UnityEngine.Random.Range(3,6);
    }

    void Update(){
        if(ss.checkPoint > 0 && ss.checkPoint <= 2 && !test1){
            meteorSpeed += 1;
            difficulty = 2;
            meteor2Probabilty = 7;
            waveWaitTime -= 0.5f;
            test1 = true;
        }
        else if(ss.checkPoint > 2 && ss.checkPoint <= 3 && !test2){
            difficulty = 2;
            meteor2Probabilty = 5;
            waveWaitTime -= 0.5f;
            test2 = true;
        }
        else if(ss.checkPoint > 3 && ss.checkPoint <= 5 && !test3){
            meteorSpeed += 2;
            difficulty = 3;
            meteor2Probabilty = 5;
            meteor3Probabilty = 7;
            waveWaitTime -= 1f;
            test3 = true;
        }
        else if(ss.checkPoint > 5 && ss.checkPoint <= 7 && !test4){
            difficulty = 3;
            meteor2Probabilty = 5;
            meteor3Probabilty = 5;
            waveWaitTime -= 1f;
            test4 = true;
        }
        else if(ss.checkPoint > 7 && !test5){
            meteorSpeed -= 2;
            difficulty = 3;
            meteor2Probabilty = 4;
            meteor3Probabilty = 4;
            waveWaitTime -= 1.5f;
            test5 = true;
        }
    }

    IEnumerator SpawnMeteors(){
        
        yield return new WaitForSeconds(startWaitTime);
        while(true){
            
            
            for(int i = 0; i < meteorCount; i++){
                rand = UnityEngine.Random.Range(1,11);
                rand2 = UnityEngine.Random.Range(1,11);
                rand3 = UnityEngine.Random.Range(1,4);
                originalSpeed = meteorSpeed;
                meteorSpeed += rand3;
                if(difficulty == 1){
                    meteorCount = UnityEngine.Random.Range(3,6);
                    meteorNo = 0;
                }
                else if(difficulty == 2){
                    meteorCount = UnityEngine.Random.Range(5,9);
                    if(rand > meteor2Probabilty){
                        meteorNo = 1;
                    }
                    else{
                        meteorNo = 0;
                    }
                }
                else{
                    meteorCount = UnityEngine.Random.Range(10,13);
                    if(rand > meteor2Probabilty){
                        if(rand2 > meteor3Probabilty){
                            meteorNo = 2;
                        }
                        else{
                            meteorNo = 1;
                        }
                    }
                    else{
                        meteorNo = 0;
                    }
                }
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Instantiate(meteor[meteorNo],spawnPosition,transform.rotation);
                meteorSpeed = originalSpeed;
                yield return new WaitForSeconds(spawnWaitTime);
            }
            
            yield return new WaitForSeconds(waveWaitTime);
        }
    }
            
}
