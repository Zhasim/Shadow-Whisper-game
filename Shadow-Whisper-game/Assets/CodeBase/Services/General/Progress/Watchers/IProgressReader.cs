using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Watchers
{
    public interface IProgressReader
    {
        void ReadProgress(OverallProgress progress);
    }
}