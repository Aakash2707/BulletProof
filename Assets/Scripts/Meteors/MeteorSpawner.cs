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
    public float spawnWaitTime, startWaitTime, waveWaitTime;
    public int meteor2Probabilty, meteor3Probabilty;
    public int rand, rand2;
    void Start()
    {
        StartCoroutine(SpawnMeteors());
        meteorCount = UnityEngine.Random.Range(3,6);
    }

    IEnumerator SpawnMeteors(){
        
        yield return new WaitForSeconds(startWaitTime);
        while(true){
            
            
            for(int i = 0; i < meteorCount; i++){
                rand = UnityEngine.Random.Range(1,11);
                rand2 = UnityEngine.Random.Range(1,11);
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
                yield return new WaitForSeconds(spawnWaitTime);
            }
            
            yield return new WaitForSeconds(waveWaitTime);
        }
    }
            
}
