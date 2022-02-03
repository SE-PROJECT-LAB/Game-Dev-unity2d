using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrapLever : MonoBehaviour
{
    [HideInInspector]
    public GameObject relatedAnimal;
    [HideInInspector]
    public GameObject relatedCage;
    
    [SerializeField] private float cageOffset;
    [SerializeField]
    private float fadeSpeed = 1f;

    [SerializeField]
    private Sprite cageOpen;


    [SerializeField]
    private float waitDuration=4f;  // Time for which chest should remain opened before closing again
    private Animator trapAnimator;
    private string OPEN_TRAP, CLOSE_TRAP;
    private EnemyRegionalSpawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        trapAnimator=GetComponent<Animator>();
        OPEN_TRAP="Base Layer.Trap Open";
        CLOSE_TRAP="Base Layer.Trap Close";
        spawner=transform.parent.GetComponent<EnemyRegionalSpawner>();
    }

    public void openTrap()
    {
        if(spawner.getLocalEnemy() <= 0)
        {
            trapAnimator.Play(OPEN_TRAP);
            relatedCage.GetComponent<SpriteRenderer>().sprite = cageOpen;
            spawner.TrapOpen=true;
            StartCoroutine(closeTrap());
        }
    }
    IEnumerator closeTrap()
    {
        float startTime=Time.time;
        while(Time.time-startTime<=waitDuration)
            yield return null;
        trapAnimator.Play(CLOSE_TRAP);
        gameObject.GetComponent<FadeInAndOut>().destroy();
        relatedAnimal.GetComponent<FadeInAndOut>().destroy();
        relatedCage.GetComponent<FadeInAndOut>().destroy();
    }
}
