using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public static ReloadGame Instance;
    public bool GameEnded{get;set;}
    public Doodler Doodler;

    private void Awake()
    {
        Instance=this;
        Doodler = Doodler != null? Doodler: FindObjectOfType<Doodler>();
        Doodler.OnDoodlerDestroyed += RestartRoutine;
    }

    
    private IEnumerator ReloadGamE()
    {  
        if (Doodler==null)
        {
            yield break;
        }
        while(!Input.anyKeyDown)
        {
            yield return null;  
        }     
        StopCoroutine(ReloadGamE());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnDestroy()
    {
        if (Doodler != null)
        {
            Doodler.OnDoodlerDestroyed -= RestartRoutine;
        }
    }
    private void RestartRoutine()
    {
        StartCoroutine(ReloadGamE());
    }
}
