using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private FloatSO scoreSO;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreSO.Value + "";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreSO.Value + "";
    }
}
