using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    [SerializeField]
    private ClimbingLadder player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            player.climbingAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            player.climbingAllowed = false;
        }
    }

}
