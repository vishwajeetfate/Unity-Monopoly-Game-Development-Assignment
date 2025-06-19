using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject playerPrefab;
    public string[] playerNames = { "Player 1", "Player 2" };
    public Player[] players;

    private int currentPlayerIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnPlayers();

        // ✅ Now that players exist, update UI
        UIManager.Instance.UpdatePlayerUI();
        UIManager.Instance.UpdateTurnText(players[0].playerName);
        UIManager.Instance.AddLog("🎮 Game Started. Waiting for Player 1...");

        StartTurn();
    }

    void SpawnPlayers()
    {
        players = new Player[playerNames.Length];

        for (int i = 0; i < playerNames.Length; i++)
        {
            GameObject go = Instantiate(playerPrefab);
            Player p = go.AddComponent<Player>();
            p.playerName = playerNames[i];
            go.name = playerNames[i];

            go.transform.position = BoardManager.Instance.tiles[0].transform.position;
            players[i] = p;
        }
    }

    public void StartTurn()
    {
        Player current = players[currentPlayerIndex];
        UIManager.Instance.UpdateTurnText(current.playerName);
        current.StartTurn();
    }

    public void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        StartTurn();
    }
}
