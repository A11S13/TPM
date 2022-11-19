using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Image Bar;
    public float fill;
    public float maxXp = 100f;

    [SerializeField]
    private FloatSO scoreSO;
    // Start is called before the first frame update
    void Start()
    {
        fill = scoreSO.Value / maxXp;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = fill;
    }
}
