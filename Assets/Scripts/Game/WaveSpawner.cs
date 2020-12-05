using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {
        SPAWNING,
        WAITING,
        COUNTING
    }
    [System.Serializable]
    public class Wave{
        public string nameWave;
        public Transform enemy;
        public int count;
        public float rate;
    }
    
    private int difficultyMode;
    private int dif_count = 0;
    private int dif_rate = 0;
    public Wave[] waves;
    private int nextWave = 0;
    public Transform [] spawnPoints;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public SpawnState state =SpawnState.COUNTING;

    private float searchCountDown = 1f;
    void Start()
    {
        difficultyMode = PlayerPrefs.GetInt("Difficulty");
        SetDifficultyMode();
        if(spawnPoints.Length == 0){
            //print("no spawnpoints");
        }
        waveCountdown = timeBetweenWaves;

    }
    void SetDifficultyMode(){
         if(difficultyMode == 2){
            dif_count = 5;
            dif_rate = 3;
        }else if(difficultyMode == 3) {
            timeBetweenWaves--;
            dif_count = 10;
            dif_rate = 5;
        }
    }
    void Update()
    {
        if(state == SpawnState.WAITING){
            if(!EnemyIsAlive()){
                WaveCompleted();
            }else{
                return;
            }
        }

        if(waveCountdown <= 0){
            if (state!= SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }else{
            waveCountdown -= Time.deltaTime;
        }
    }
    void WaveCompleted(){
        //print("Wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if(nextWave+1 > waves.Length - 1){
            nextWave= 0;
           // print("complete all waves");
        }else{
            nextWave++;
        }
        
    }
    bool EnemyIsAlive(){
        searchCountDown -=Time.deltaTime;
        if(searchCountDown <= 0f){
            searchCountDown = 1f;
            if(GameObject.FindGameObjectWithTag("enemy") == null){
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave){
        //print("Spawning wave" + _wave.nameWave);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count + dif_count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1/(_wave.rate+ dif_rate));
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy){
        //print("Hola " + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length)];
        Instantiate(_enemy,_sp.position,_sp.rotation);
    }
}
