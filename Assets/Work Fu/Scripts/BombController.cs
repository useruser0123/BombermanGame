using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("bomb")]
    public GameObject bombPrefab;
    public KeyCode inputkey = KeyCode.Space;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombRemaining;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    [Header("Descructible")]
    public Tilemap descructibleTiles;
    public Descructible descructiblePrefab;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip explosionSound;

    private void OnEnable()
    {
        bombRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombRemaining > 0 && Input.GetKeyDown(inputkey))
        {
            StartCoroutine(PlaceBomb());    
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombRemaining--;

        yield return new WaitForSeconds(bombFuseTime);

        // å¯â âπÇçƒê∂
        audioSource.PlayOneShot(explosionSound);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb);
        bombRemaining++;    
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDescructible(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void ClearDescructible(Vector2 position)
    {
        Vector3Int cell = descructibleTiles.WorldToCell(position);
        TileBase tile = descructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(descructiblePrefab, position, Quaternion.identity);
            descructibleTiles.SetTile(cell, null);
        }
    }

    public void AddBomb()
    {
        bombAmount++;
        bombRemaining++;
    }
}
