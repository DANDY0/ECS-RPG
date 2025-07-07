using Code.Progress;
using Entitas;

namespace Code.Meta.Features.Storage
{
    public class StorageComponents
    {
        [Meta] public class Storage : ISavedComponent {  }
        [Meta] public class Gold : ISavedComponent { public float Value; }
        [Meta] public class GoldPerSecond : ISavedComponent { public float Value; }

    }
}