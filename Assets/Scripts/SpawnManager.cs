using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager GM = null; //empty variable
    [SerializeField] private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    IEnumerator EnemySpawn()
    {
        //loop
        //for - counting
        //while - boolean loop
        while (true) // change test later
        {
            Instantiate(Enemy, new Vector3(Random.Range(-7.0f, 7.0f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
