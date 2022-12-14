using UnityEngine;
using UnityEditor;

namespace GraphProcessor
{
	[ExecuteAlways]
	public class DeleteCallback : UnityEditor.AssetModificationProcessor
	{
        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            if (!IsScene(path))
            {
                var objects = AssetDatabase.LoadAllAssetsAtPath(path);

                foreach (var obj in objects)
                {
                    if (obj is BaseGraph b)
                    {
                        foreach (var graphWindow in Resources.FindObjectsOfTypeAll<BaseGraphWindow>())
                            graphWindow.OnGraphDeleted();

                        b.OnAssetDeleted();
                    }
                }
            }


            return AssetDeleteResult.DidNotDelete;
		}

        //prevent error for 'Do not use ReadObjectThreaded on scene objects!'
        //https://answers.unity.com/questions/924502/unity-5-giving-errors-on-older-project-do-not-use.html
        static bool IsScene(string path)
        {
            return typeof(SceneAsset).Equals(AssetDatabase.GetMainAssetTypeAtPath(path));
        }
	}
}