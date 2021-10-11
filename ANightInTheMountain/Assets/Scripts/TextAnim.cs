using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [SerializeField]
    private string text;
    [SerializeField]
    private float timeBetweenLetters;

    private int textIndex = 0;
    private TextMeshProUGUI textBox;

    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TextAnimation(textIndex));
    }

    private IEnumerator TextAnimation(int index)
    {
        Debug.Log(index);
        yield return new WaitForSeconds(timeBetweenLetters);
        if (index < text.Length) 
        {
            textBox.text += text[index];
            index++;
            StartCoroutine(TextAnimation(index));
        }
    }
}
