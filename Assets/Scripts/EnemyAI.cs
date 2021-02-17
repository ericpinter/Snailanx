using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float MoveSpeed;
    public bool ignoreTrigger;
    public Collider2D triggerBox;
    public GameObject Stamp;
    public GameObject player;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = (player.transform.position - this.transform.position).normalized;
        this.transform.position += MoveSpeed * v;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("collided with " + other.gameObject);
        if (other.gameObject.CompareTag("Spike") && !ignoreTrigger)
        {


            print("turning off");
            this.gameObject.SetActive(false);
            Camera c = FindObjectOfType<Camera>();
            Vector3 averagePosition = (c.transform.position + this.transform.position) / 2.0f;

            AudioSource.PlayClipAtPoint(deathSound, averagePosition,1f);

            if (this.CompareTag("Boss"))
            {
                Stamp.GetComponent<Collider2D>().enabled = true;
                c.GetComponent<FollowCam>().player = player;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    void removeTrigger()
    {
        this.triggerBox.enabled = false;
        ignoreTrigger = false;
    }

    void setSpeed(float speed)
    {
        this.MoveSpeed = speed;
    }

}
