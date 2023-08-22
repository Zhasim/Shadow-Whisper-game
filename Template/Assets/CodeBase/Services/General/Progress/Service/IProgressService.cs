using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Service
{
    public interface IProgressService
    {
        OverallProgress OverallProgress { get; set; }
    }
}