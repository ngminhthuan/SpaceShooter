using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public int PlayerHealth = 100;
    [SerializeField] ShipMovementCtrl shipMovementCtrl;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void MovePlayer(float deltaX, float speed)
    {
        Vector3 newPosition = transform.position + new Vector3(deltaX * Time.deltaTime * speed, 0, 0);
        transform.position = newPosition;
    }
 
    public void GetDamage(int damage)
    {
        PlayerHealth -= damage;
        if(PlayerHealth < 0)
        {
            GameView.Instance.gameObject.SetActive(false);
            ResultView.Instance.gameObject.SetActive(true);
            ResultView.Instance.text.text = "You Lost";
        }
        GameView.Instance.ReloadView();
    }

    public void ResetPlayer()
    {
        PlayerHealth = 100;

    }
}
