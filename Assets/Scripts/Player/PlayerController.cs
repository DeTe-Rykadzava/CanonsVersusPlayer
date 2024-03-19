using UI;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField] private UIController uIController;
        [SerializeField] private CameraControl cameraControl;
        
        private Player _player;
        private bool _playerIsNull = true;

        private PlayerGUI _playerUI;
        private GameObject _cameraPoint;
        private void Awake()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var player = Instantiate<Player>(playerPrefab, spawnPoint, Quaternion.Euler(0, -90, 0));
            player.gameObject.name = "Player";
            var playerMovement = player.GetComponent<PlayerMovement>();
            _player = player;
            _playerIsNull = false;
            
            // player UI
            var playerUigGameObject = new GameObject
            {
                name = "PlayerUI"
            };
            var playerUI = playerUigGameObject.AddComponent<PlayerGUI>();
            playerUI.player = _player;
            playerUI.hitPointsText = uIController.hitPointsText;
            playerUI.hitPointsImage = uIController.hitPointsImage;
            _playerUI = playerUI;
            
            // camera point
            var cameraPoint = new GameObject { name = "CameraPoint" };
            cameraPoint.transform.position = _player.transform.position;
            _cameraPoint = cameraPoint;
            playerMovement.cameraPoint = _cameraPoint.transform;
            cameraControl.cameraPoint = _cameraPoint.transform;
        }

        private void LateUpdate()
        {
            if(_playerIsNull) return;
            if (!_player.IsDead) return;
            
            Debug.Log("Player dead");
            RespawnPlayer();
        }

        
        
        private void RespawnPlayer()
        {
            Destroy(_player.gameObject);
            var player = Instantiate<Player>(playerPrefab, spawnPoint, Quaternion.Euler(0, -90, 0));
            player.gameObject.name = "Player";
            var playerMovement = player.GetComponent<PlayerMovement>();
            _player = player;
            _playerIsNull = false;
            _playerUI.player = _player;
            playerMovement.cameraPoint = _cameraPoint.transform;
        }
    }
}