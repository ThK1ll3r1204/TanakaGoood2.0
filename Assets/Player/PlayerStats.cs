using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float _pLife = 100f;
    

    private void Start()
    {
        
    }

    void Update()
    {
       

        if (_pLife <= 0f)
        {
            Die();
        }
    }


    public void Die()
    {
        //Efectivamente murio
        Debug.Log("Muerto");
        SceneManager.LoadScene(0);
    }
}
