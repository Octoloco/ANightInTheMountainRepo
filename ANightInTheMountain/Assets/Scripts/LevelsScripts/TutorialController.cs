using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] Transform spawn;

    [SerializeField] GameObject tutorialSprite;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        tutorialSprite.transform.position = spawn.transform.position;
        tutorialSprite.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        tutorialSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
