using Cinemachine;
using UnityEngine;

namespace MT.Core
{
    public class CamerasSwithcer : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _startCamera;
        [SerializeField] private CinemachineVirtualCamera _gameCamera;

        public void GameCamera()
        {
            _gameCamera.gameObject.SetActive(true);
        }
    }
}
