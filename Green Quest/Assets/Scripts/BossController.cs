using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [System.Serializable]
    public class Attack
    {
        public Transform AttackPrefab;
        public float probability;
        [HideInInspector]
        public static float LastAttack = -1;
    }
    public float AttackCooldown;
    public Attack[] AttackList;
    public int HealthRemaing;
    public UnityEvent OnDeath;
    public GameObject Smog;
    public static BossController instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (!GetComponent<EnemyController>().stunned)
        {
            float prob = Random.value;
            foreach (Attack attack in AttackList)
            {
                if (Attack.LastAttack < 0 || Time.time - Attack.LastAttack > AttackCooldown)
                {
                    if (prob > 0 && prob < attack.probability)
                    {
                        Attack.LastAttack = Time.time;
                        Instantiate(attack.AttackPrefab, transform.position + Vector3.up, Quaternion.identity);
                    }
                }
                prob -= attack.probability;
            }
        }
    }

    public void OnHit()
    {
            if (HealthRemaing > 1)
            {
           

            HealthRemaing--;
                GetComponent<EnemyController>().LaunchPlayer(12*Vector2.up);
            SetStunned(5f);
            }
            else
            {
           

            OnDeath.Invoke();
            }
    }
    public void SetStunned(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(StunAnimation(duration));
        StartCoroutine(Respawn(duration));
    }
    public void StartVolnurable(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(Volunarable(duration));
    }
    private IEnumerator StunAnimation(float duration)
    {
        GetComponent<EnemyController>().stunned = true;
        Color currColor;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        renderer.color = Color.white;
        for (int i = 0; i * 0.4 < duration; i++)
        {
            currColor = renderer.color;
            currColor.a = 0.8f;
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
            currColor = renderer.color;
            currColor.a = 1f;
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
        }
        GetComponent<EnemyController>().stunned = false;

        GetComponentInChildren<Animator>().enabled = true;
    }
    private IEnumerator Respawn(float duration)
    {
        gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
        yield return new WaitForSeconds(duration);
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        GetComponent<EnemyController>().Invincible = true;
        Smog.SetActive(true);
    }
    private IEnumerator Volunarable(float duration)
    {
        GetComponent<EnemyController>().Invincible = false;
        GetComponent<EnemyController>().stunned = true;
        Smog.SetActive(false);
        yield return new WaitForSeconds(duration);
        GetComponent<EnemyController>().stunned = false;
        GetComponent<EnemyController>().Invincible = true;
        Smog.SetActive(true);
    }
}