using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeGenerator : MonoBehaviour, IResetable
{
    [SerializeField] private Fox _player;
    [SerializeField] private Transform _playerSpawn;
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
        SetPlayer();
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

    public void ResetState()
    {
        bool isSpawned;

        do
        {
            isSpawned = TryDespawnFirstSpawned();
        }
        while (isSpawned);

        if (_startLandscapePart != null)
        {
            _landscapePartsPool.Remove(_startLandscapePart);
            _landscapePartsPool.Insert(0, _startLandscapePart);
        }

        Spawn(Vector3.zero);
        SetPlayer();
    }

    private void SetPlayer()
    {
        _player.transform.position = _playerSpawn.position;
    }

    private LandscapePart GenerateRandomLandscapePart()
    {
        LandscapePart part = Instantiate(_landscapePartPrefab, _container.transform.position, Quaternion.identity, _container.transform);
        part.Initialize(GetRandomElement(_pathPrefabs), GetRandomElement(_layoutPrefabs), GetRandomElement(_layoutPrefabs));
        return part;
    }

    private void Spawn(Vector3 position)
    {
        if (TryGetLandscapePart(out LandscapePart landscapePart) == false)
        {
            if (TryDespawnFirstSpawned() == false)
                return;

            landscapePart = _landscapePartsPool.First();
        }

        landscapePart.gameObject.SetActive(true);
        landscapePart.transform.position = position;
        _landscapePartsPool.Remove(landscapePart);
        _spawnedLandscapeParts.Add(landscapePart);
        _lastSpawned = landscapePart;
    }

    private bool TryGetLandscapePart(out LandscapePart landscapePart)
    {
        landscapePart = _landscapePartsPool.FirstOrDefault();
        return landscapePart != null;
    }

    private bool TryDespawnFirstSpawned()
    {
        LandscapePart firstSpawned = _spawnedLandscapeParts.FirstOrDefault();

        if (firstSpawned != null)
        {
            AddLandscapePartToPool(firstSpawned);
            _spawnedLandscapeParts.Remove(firstSpawned);
        }

        return firstSpawned != null;
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
