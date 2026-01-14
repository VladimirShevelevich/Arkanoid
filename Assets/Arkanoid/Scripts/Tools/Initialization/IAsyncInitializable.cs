using Cysharp.Threading.Tasks;

namespace Arkanoid.Tools.Initialization
{
    public interface IAsyncInitializable
    {
        UniTask InitializeAsync();
    }
}