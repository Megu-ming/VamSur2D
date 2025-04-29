using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float attackSpeed = 1f;

    private float attackCooldown;
    private float attackTimer;

    void Start()
    {
        attackCooldown = 1f / attackSpeed;
        attackTimer = 0f;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            GameObject target = FindClosestEnemy();

            // 적이 없을 경우 오른쪽(x축 양의 방향)으로 공격
            Vector2 direction;
            if (target != null)
            {
                direction = ((Vector2)target.transform.position - (Vector2)firePoint.position).normalized;
            }
            else
            {
                direction = Vector2.right; // 기본 공격 방향
            }

            Attack(direction);
            attackTimer = 0f;
        }
    }

    void Attack(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(enemy.transform.position, currentPos);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }

        return closest;
    }

    public void SetAttackSpeed(float newSpeed)
    {
        attackSpeed = newSpeed;
        attackCooldown = 1f / attackSpeed;
    }
}
