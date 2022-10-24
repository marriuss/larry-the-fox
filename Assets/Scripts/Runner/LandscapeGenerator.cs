using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeGenerator : MonoBehaviour
{
    [SerializeField] private LandscapePart _landscapePartPrefab;
    [SerializeField] private LandscapeLayout[] _layoutPrefabs;
    [SerializeField] private Path[] _pathPrefabs;
    [SerializeField] private GameObject _container;
    [SerializeField] private LandscapePart _startLandscapePart;
    [SerializeField] private float _maxSpawnedAmount;
    [SerializeField] private float _spawnViewDistance;
    [SerializeField] private Vector3 _spawnOffset;

    private List<LandscapePart> _landscapePartsPool;
    private List<LandscapePart> _spawnedLandscapeParts;
    private LandscapePart _lastSpawned;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _landscapePartsPool = new List<LandscapePart>();
        _spawnedLandscapeParts = new List<LandscapePart>();

        if (_startLandscapePart != null)
        {
            _maxSpawnedAmount--;
            AddLandscapePartToPool(_startLandscapePart);
        }

        for (int i = 0; i < _maxSpawnedAmount; i++)
        {
            LandscapePart part = GenerateRandomLandscapePart();
            AddLandscapePartToPool(part);
        }

        Spawn(Vector3.zero);
    }

    private void Update()
    {
        if (_lastSpawned != null)
        {
            Vector3 lastSpawnedPosition = _lastSpawned.transform.position;

            if (Vector3.Distance(_camera.transform.position, lastSpawnedPosition) < _spawnViewDistance)
                Spawn(lastSpawnedPosition + _spawnOffset);
        }
    }

    private LandscapePart GenerateRandomLandscapePart()
    {
        LandscapePart part = Instantiate(_landscapePartPrefab, _container.transform.position, Quaternion.identity, _container.transform);
        part.Initialize(GetRandomElement(_pathPrefabs), GetRandomElement(_layoutPrefabs), GetRandomElement(_layoutPrefabs));
        return part;
    }

    private bool TryGetLandscapePart(out LandscapePart landscapePart)
    {
        landscapePart = _landscapePartsPool.FirstOrDefault();

        return landscapePart != null;
    }

    private void Spawn(Vector3 position)
    {
        if (TryGetLandscapePart(out LandscapePart landscapePart) == false)
        {
            DespawnFirstSpawned();

            if (TryGetLandscapePart(out landscapePart) == false)
                return;
        }

        landscapePart.gameObject.SetActive(true);
        landscapePart.transform.position = position;
        _landscapePartsPool.Remove(landscapePart);
        _spawnedLandscapeParts.Add(landscapePart);
        _lastSpawned = landscapePart;
    }

    private void DespawnFirstSpawned()
    {
        LandscapePart firstSpawned = _spawnedLandscapeParts.FirstOrDefault();
        
        if (firstSpawned != null)
        {
            AddLandscapePartToPool(firstSpawned);
            _spawnedLandscapeParts.Remove(firstSpawned);
        }
    }

    private void AddLandscapePartToPool(LandscapePart landscapePart)
    {
        landscapePart.gameObject.SetActive(false);
        _landscapePartsPool.Add(landscapePart);

    }

    private T GetRandomElement<T>(T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
