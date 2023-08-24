using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Generator
{
    public interface IProgressGenerator
    {
        OverallProgress GenerateNewProgress();
    }
}