using System;
using ArtifactorySharp.Models.Search;
using RestSharp;

namespace ArtifactorySharp.Interfaces
{
    public interface IArtifactory : IDisposable
    {
        Uri Uri { get; }
        
        string UserAgent { get; }

        IRepositories Repositories { get; }

        IRepository GetRepository(string repo);

        QuickSearchConfiguration Search();

        IRestResponse RestCall(IRestRequest request);
    }
}
