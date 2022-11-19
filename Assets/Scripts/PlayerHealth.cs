using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float points;
    public float maxHealth = 10;
    public float fill;
    public Image bar;
    public GameOverScreen GameOverScreen;

    private float damage;


    [SerializeField]
    private GameObject getDamage;
    [SerializeField]
    private GameObject enemyFragments;
    [SerializeField]
    private GameObject bonusPikup;
    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO damageSO;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        points = scoreSO.Value;
        damage = damageSO.Value;
        fill = 1f;
    }

    void Update()
    {
        bar.fillAmount = fill;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        fill = health / maxHealth;
        if (health <= 0)
        {
            GameOverScreen.Setup();
            bar.GetComponent<Image>().enabled = false;
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(getDamage, other.transform.position, Quaternion.identity);
            Instantiate(enemyFragments, other.transform.position, Quaternion.identity);
            
            Destroy(other.gameObject);
            TakeDamage(damage);
        }
        if (other.gameObject.CompareTag("Bonus"))
        {
            Instantiate(bonusPikup, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            scoreSO.Value++;
            points = scoreSO.Value;
        }
    }
}