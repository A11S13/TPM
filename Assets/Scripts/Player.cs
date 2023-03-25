using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{  
    [SerializeField]
    private GameObject getDamage;
    [SerializeField]
    private GameObject bonusPikup;
    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO damageSO;

    private float damage;
    public float health;
    public float points;
    public float maxHealth = 10;
    public float fill;
    public Image healthBar;
    public GameOverScreen GameOverScreen;

    void Start()
    {
        health = maxHealth;
        points = scoreSO.Value;
        damage = damageSO.Value;
        fill = 1f;
    }

    void Update()
    {
        healthBar.fillAmount = fill;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        fill = health / maxHealth;
        if (health <= 0)
        {
            GameOverScreen.Setup();
            healthBar.GetComponent<Image>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(getDamage, other.transform.position, Quaternion.identity);
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