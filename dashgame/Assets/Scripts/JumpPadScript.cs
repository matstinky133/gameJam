using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _force = 1f;


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody2D rb = collision.rigidbody;

    //        // rb.totalForce = new Vector2(rb.totalForce.x, 0);

    //        rb.totalForce = Vector2.zero;
    //        rb.AddRelativeForce(Vector2.up * _force, ForceMode2D.Impulse);
            
    //        Debug.DrawLine(collision.transform.position, collision.transform.position + new Vector3(0, (rb.GetRelativePointVelocity(collision.transform.position).y), 0), Color.red, 1);

    //        Debug.Log(rb.GetRelativePointVelocity(collision.transform.position));
    //    }
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            // rb.totalForce = new Vector2(rb.totalForce.x, 0);

            rb.linearVelocityY = 0;
            rb.AddRelativeForce(Vector2.up * _force, ForceMode2D.Impulse);

            Debug.DrawLine(collision.transform.position, collision.transform.position + new Vector3(0, (rb.GetRelativePointVelocity(collision.transform.position).y), 0), Color.red, 1);

            Debug.Log(rb.GetRelativePointVelocity(collision.transform.position));
        }
    }

}
