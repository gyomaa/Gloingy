using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    [SerializeField] private string loadlevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gloingy") || other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadlevel);
        }
    }

}
