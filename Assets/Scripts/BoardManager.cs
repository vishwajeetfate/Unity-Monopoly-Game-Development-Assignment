using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    public GameObject tilePrefab;
    public int tileCount = 24;
    public float tileSize = 1.5f;

    public List<Tile> tiles = new List<Tile>();

    private void Awake()
    {
        Instance = this;
        GenerateBoard();
    }

    void GenerateBoard()
    {
        int tilesPerSide = tileCount / 4;
        Vector2 startPos = new Vector2(-tilesPerSide / 2f * tileSize, -tilesPerSide / 2f * tileSize);
        int index = 0;

        for (int i = 0; i < tileCount; i++)
        {
            Vector2 pos;

            if (i < tilesPerSide) // Bottom
                pos = startPos + new Vector2(i * tileSize, 0);
            else if (i < tilesPerSide * 2) // Right
                pos = startPos + new Vector2((tilesPerSide - 1) * tileSize, (i - tilesPerSide) * tileSize);
            else if (i < tilesPerSide * 3) // Top
                pos = startPos + new Vector2((tilesPerSide - 1 - (i - 2 * tilesPerSide)) * tileSize, (tilesPerSide - 1) * tileSize);
            else // Left
                pos = startPos + new Vector2(0, (tilesPerSide - 1 - (i - 3 * tilesPerSide)) * tileSize);

            GameObject tileGO = Instantiate(tilePrefab, pos, Quaternion.identity);
            tileGO.name = $"Tile_{index}";
            tileGO.transform.SetParent(transform);

            Tile tile = AssignTileType(tileGO, index);
            tile.index = index;

            tiles.Add(tile);
            index++;
        }
    }

    Tile AssignTileType(GameObject tileGO, int index)
    {
        SpriteRenderer sr = tileGO.GetComponent<SpriteRenderer>();
        TextMeshPro label = tileGO.GetComponentInChildren<TextMeshPro>();

        switch (index)
        {
            case 0:
                sr.color = Color.cyan;
                if (label != null) label.text = "Start";
                return tileGO.AddComponent<StartTile>();

            case 6:
                sr.color = Color.red;
                if (label != null) label.text = "Jail";
                return tileGO.AddComponent<JailTile>();

            case 12:
                sr.color = Color.magenta;
                if (label != null) label.text = "Go to Jail";
                return tileGO.AddComponent<GoToJailTile>();

            case 3:
            case 9:
            case 15:
            case 21:
                sr.color = Color.yellow;
                if (label != null) label.text = "Chance";
                return tileGO.AddComponent<ChanceTile>();

            case 5:
                sr.color = Color.gray;
                if (label != null) label.text = "Electric Co.";
                return tileGO.AddComponent<UtilityTile>();

            case 8:
                sr.color = Color.blue;
                if (label != null) label.text = "Railway";
                SpecialTile rail = tileGO.AddComponent<SpecialTile>();
                rail.typeName = "Railway";
                return rail;

            case 14:
                sr.color = Color.green;
                if (label != null) label.text = "Airport";
                SpecialTile airport = tileGO.AddComponent<SpecialTile>();
                airport.typeName = "Airport";
                return airport;

            case 18:
                sr.color = Color.black;
                if (label != null) label.text = "Harbor";
                SpecialTile harbor = tileGO.AddComponent<SpecialTile>();
                harbor.typeName = "Harbor";
                return harbor;

            default:
                sr.color = Color.white;
                if (label != null) label.text = $"City {index}";
                PropertyTile property = tileGO.AddComponent<PropertyTile>();
                property.price = 100 + index * 10;
                property.rent = Mathf.RoundToInt(property.price * 0.1f);
                return property;
        }
    }


}
