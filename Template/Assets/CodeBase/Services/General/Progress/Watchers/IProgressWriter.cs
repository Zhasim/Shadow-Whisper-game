using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Watchers
{
    public interface IProgressWriter : IProgressReader
    {
        void WriteProgress(OverallProgress progress);
    }
}