using Models.ModelConfigurations;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    public GameObject cameraObject;
    private void Awake()
    {
        LoadModel(Utility.CommonVariables.PrefabName);
        enabled = false;
    }

    private void LoadModel(string prefabName)
    {
        if (prefabName == string.Empty)
        {
            Utility.ChangeScene.ChangeToScene(Utility.CommonVariables.HomeScene);
            return;
        }

        var assetBundle = Utility.LocalStorageManager.AssetBundleManager.Instance.
            LoadAssetBundle(prefabName, () =>
        {
            Utility.ChangeScene.ChangeToScene(Utility.CommonVariables.HomeScene);
        });

        var prefab = assetBundle.LoadAllAssets<GameObject>()[0];
        var prefabConfigurationsText = assetBundle.LoadAllAssets<TextAsset>()[0];
        var prefabConfigurations = JsonUtility.FromJson<ModelConfigs>(prefabConfigurationsText.text);
        SetupCamera(prefab, prefabConfigurations);
        SetupPrefab(prefab, prefabConfigurations);
    }

    private void SetupPrefab(GameObject prefab, ModelConfigs prefabConfigurations)
    {
        //setup prefab
        var instantiated = Instantiate(prefab);

        instantiated.transform.position = prefabConfigurations.prefab.position.GetVector3();
        instantiated.transform.rotation = Quaternion.Euler(prefabConfigurations.prefab.eulerRotation.GetVector3());
        instantiated.transform.localScale = prefabConfigurations.prefab.scale.GetVector3();
        
        OnAfterSetupPrefab(instantiated);
    }
    protected virtual void OnAfterSetupPrefab(GameObject prefab) { }
    private void SetupCamera(GameObject prefab, ModelConfigs prefabConfigurations)
    {
        //setup camera transform
        cameraObject.transform.position = prefabConfigurations.prefab.position.GetVector3();
        cameraObject.transform.rotation = Quaternion.Euler(prefabConfigurations.camera.eulerRotation.GetVector3());

        //setup camera fov
        var cam = cameraObject.GetComponentInChildren<Camera>();
        cam.fieldOfView = prefabConfigurations.camera.fieldOfView.max;
        cam.transform.position = prefabConfigurations.camera.position.GetVector3();
        
        //setup CameraManager
        var cameraManager = cameraObject.GetComponent<Utility.CameraManager.CameraManager>();
        cameraManager.cameraConfigs = prefabConfigurations.camera;
        cameraManager.model = prefab;

        OnAfterSetupCamera(cameraObject);
    }
    protected virtual void OnAfterSetupCamera(GameObject cameraObj) { }
}
