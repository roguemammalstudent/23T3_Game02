public class Collector : MonoBehaviour
{
    [SerializeField] Backpack backpack = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            backpack.UpdateKeys(1);
            Destroy(collision.gameobject);
        }
    }
}