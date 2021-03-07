using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [Space]
    [Header("Stats")]
    public float _currentStress = 0;
    public float changePerSecond = -1;
    public int maxHealth = 110;
    public int _currenthHealth = 110;
    public int _currentKey;
    public int _saveHealth = 0;
    [Space]
    [Header("Objects")]
    public LevelLoader level;
    public HealthBar healthBar;
    public KeyBar keybar;
    // Start is called before the first frame update
    void Awake()
    {
        _saveHealth = PlayerPrefs.GetInt("save");
        if (_saveHealth == 1)
        {
            _currenthHealth = PlayerPrefs.GetInt("health");
        }
        else if (_saveHealth == 0)
        {
            _currenthHealth = maxHealth;
        }
        _currentKey = PlayerPrefs.GetInt("keys");
        PlayerPrefs.DeleteAll();
    }
    void Start()
    {
        level = FindObjectOfType<LevelLoader>();
        healthBar.SetHealth(_currenthHealth);
        keybar.Setkey(_currentKey);
    }

    // Update is called once per frame
    void Update()
    {
        _currentStress = Mathf.Clamp(_currentStress + changePerSecond * (Time.deltaTime * 2), 0, 100);
         
        if (_currenthHealth == 25)
        {
            StartCoroutine(StressInducer());
        }

        if (_currenthHealth <= 0)
        {
            level.GameOver();
        }
    }
    IEnumerator StressInducer()
    {
        _currentStress = Mathf.Clamp(_currentStress + 4f * Time.deltaTime, 0, 100);
        yield return new WaitForSeconds(10f);
    }

    public void AddHealth(int health)
    {
        _currenthHealth += health;
        healthBar.SetHealth(_currenthHealth);
    }
    public void TakeDamage(int damage)
    {
        _currenthHealth -= damage;
        healthBar.SetHealth(_currenthHealth);
    }

    public void AddKey(int key)
    {
        _currentKey += key;
        keybar.Setkey(_currentKey);
    }

    public void AddStress()
    {
        _currentStress++;
    }
}
