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
        public float Cooldown;
        [HideInInspector]
        public float LastAttack = -1;
    }

    public Attack[] AttackList;
    public int HealthRemaing;
    public UnityEvent OnDeath;

    void Update()
    {
        if (!GetComponent<EnemyController>().stunned)
        {
            foreach (Attack attack in AttackList)
            {
                float prob = Random.value;
                if (attack.LastAttack < 0 || Time.time - attack.LastAttack > attack.Cooldown)
                {
                    attack.LastAttack = Time.time;
                    if (prob > 0 && prob < attack.probability)
                    {
                        Instantiate(attack.AttackPrefab, transform.position + Vector3.up, Quaternion.identity);
                    }
                    prob -= attack.probability;
                }
            }
        }
    }

    public void OnHit()
    {
            if (HealthRemaing > 1)
            {
           

            HealthRemaing--;
                GetComponent<EnemyController>().LaunchPlayer(Vector2.up);
            SetStunned(5f);
            }
            else
            {
           

            OnDeath.Invoke();
            }
    }
    public void SetStunned(float duration)
    {
        StartCoroutine(Stun(duration));
    }
    private IEnumerator Stun(float duration)
    {
        gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
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
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }
}