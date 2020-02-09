using UnityEngine;
using star_system;
using missile_system;

namespace ui
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private EnvironmentCreator _environmentCreator;

        public void Launch()
        {
            MissileLauncher launcher = _environmentCreator.GetPlayerLauncher();
            {
                if (!launcher)
                    return;

                launcher.Launch();
            }
        }
    }
}