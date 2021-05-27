using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UIConsole
{
    class SceneManager
    {
        private static SceneManager mInstance;
        private readonly LinkedList<Scene> mSceneList;

        public static SceneManager Instance
        {
            get
            {
                if (mInstance is null) // wenn noch kein Objekt erstellt wurde holen wir das nach. "Lazy Initialization"
                    mInstance = new(); // das einzige new für den SceneManager das es je geben wird
                return mInstance;
            }
        }

        private SceneManager()
        {
            // niemand darf einen SceneManager erstellen, darum Private
            mSceneList = new();
        }


        public void Update() => mSceneList.Last.Value.Update();
        public void Draw() => mSceneList.Last.Value.Draw();

        public int Count
        {
            get
            {
                return mSceneList.Count;
            }
        }

        public void AddScene(Scene SceneToAdd)
        {
            mSceneList.AddLast(SceneToAdd);
        }

        public void RemoveScene(Scene SceneToRemove)
        {
            mSceneList.Remove(SceneToRemove);
        }
    }
}
