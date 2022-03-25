using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Transform[] m_spawnpoints;
    public GameObject m_enemyprefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    void OnEnable()
    {
        Health.OnEnemyKilled += SpawnNewEnemy;
    }

    // Update is called once per frame
    void SpawnNewEnemy()
    {

        Instantiate(m_enemyprefab, m_spawnpoints[0].transform.position, Quaternion.identity);
    }
}
