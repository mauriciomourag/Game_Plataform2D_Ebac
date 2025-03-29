using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int demage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();
        if(health != null)
        {
            health.Demage(demage);
        }
    }

}
