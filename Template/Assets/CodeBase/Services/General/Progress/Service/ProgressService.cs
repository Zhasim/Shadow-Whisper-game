using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Service
{
    public class ProgressService : IProgressService
    {
        public OverallProgress OverallProgress { get; set; }
    }
}