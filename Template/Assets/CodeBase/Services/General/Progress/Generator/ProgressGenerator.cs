using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Generator
{
    public class ProgressGenerator : IProgressGenerator
    { 
        public OverallProgress GenerateNewProgress() => new ();
    }
}