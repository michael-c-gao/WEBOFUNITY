using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI LifestealText;
    public TextMeshProUGUI SpeedText;

    public float health = 100;
    public float damage = 10;
    public float lifesteal = 0;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + health;
        DamageText.text = "Damage: " + damage;
        LifestealText.text = "Lifesteal: " + lifesteal;
        SpeedText.text = "Speed: " + speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StatIncreaser"))
        {
            switch (other.GetComponent<StatIncreaserScript>().getScaleType())
            {
                case "health":
                    health += 1;
                    break;
                case "damage":
                    damage += 1;
                    break;
                case "lifesteal":
                    lifesteal += 1;
                    break;
                case "speed":
                    speed += 1;
                    break;
                default:
                    health += 1;
                    break;
            }
        }
    }

}
