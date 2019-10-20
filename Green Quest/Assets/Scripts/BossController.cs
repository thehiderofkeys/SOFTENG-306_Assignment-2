using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    public int HealthRemaing;
    public UnityEvent OnDeath;

    public void OnHit()
    {
            if (HealthRemaing > 1)
            {
           

            HealthRemaing--;
                GetComponent<EnemyController>().LaunchPlayer(PlayerController.instance);
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
