using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileColorChanger : MonoBehaviour
{
    public float lerpDuration = 3f;
    public float endAlpha = 0.2f;

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        foreach (Vector3Int tilePosition in tilemap.cellBounds.allPositionsWithin)
        {
            tilemap.SetTileFlags(tilePosition, TileFlags.None);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Light"))
        {
            Vector3 centre = collider.bounds.center;
            Vector3 min = collider.bounds.min;
            Vector3 max = collider.bounds.max;

            Vector3[] corners =
            {
                new Vector3(min.x, min.y, 0f), new Vector3(min.x, max.y, 0f), new Vector3(min.x, centre.y, 0f),
                new Vector3(max.x, min.y, 0f), new Vector3(max.x, max.y, 0f), new Vector3(max.x, centre.y, 0f),
            };

            foreach (Vector3 corner in corners)
            {
                Vector3Int tilePosition = tilemap.WorldToCell(corner);
                if (tilemap.HasTile(tilePosition))
                {
                    tilemap.SetColor(tilePosition, Color.white);
                    //StartCoroutine(LerpColour(tilePosition));
                }
            }
        }
    }

    IEnumerator LerpColour(Vector3Int tilePosition)
    {
        Color lerpedColour = tilemap.GetColor(tilePosition);
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            lerpedColour = new Color(1, 1, 1, 0);
            tilemap.SetColor(tilePosition, lerpedColour);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        lerpedColour = new Color(255, 255, 255, 1f);
        tilemap.SetColor(tilePosition, lerpedColour);
    }
}
