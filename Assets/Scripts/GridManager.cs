using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid() 
    {
        //Create a dictionary of all the tiles
        _tiles = new Dictionary<Vector2, Tile>();

        //Generate grid along x and y axis
        for (int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++) {
                
                //create prefabs of the tiles with the "Tile" tag
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.tag = "Tile";
                
                var spriteRenderer = spawnedTile.GetComponent<SpriteRenderer>();

                //change sorting layer and color of the tile sprite
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingLayerName = "Infection";
                    spriteRenderer.sortingOrder = 1;

                    Color tileColor = spriteRenderer.color; 
                    tileColor.a = 0f;
                    spriteRenderer.color = tileColor;
                }

                //add a Sprite Mask to each tile
                if (spawnedTile.GetComponent<SpriteMask>() == null)
                {
                    var SpriteMask = spawnedTile.gameObject.AddComponent<SpriteMask>();
                }

                //add a box collider to each tile
                if (spawnedTile.GetComponent<Collider2D>() == null)
                {
                    var Collider = spawnedTile.gameObject.AddComponent<BoxCollider2D>();
                    Collider.isTrigger = true;
                }
                
    
                _tiles[new Vector2(x, y)] = spawnedTile;
            }


        }

    }

    public Tile GetTilePosition(Vector2 pos) 
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile; 
        }

        return null;
    }
}
