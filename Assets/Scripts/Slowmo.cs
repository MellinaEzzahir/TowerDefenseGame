public class Slowmo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 1.5f;
    [SerializeField] private float aps = 1f; //attack per second
}
