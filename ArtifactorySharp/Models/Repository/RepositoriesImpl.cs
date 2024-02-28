using ArtifactorySharp.Interfaces;
using RestSharp;

namespace ArtifactorySharp.Models.Repository
{
    /// <summary>
    /// Implementation of the IRepositories interface.
    /// </summary>
    public class RepositoriesImpl : IRepositories
    {
        private readonly IRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoriesImpl"/> class.
        /// </summary>
        /// <param name="restClient">The rest client.</param>
        public RepositoriesImpl(IRestClient restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// Returns a repository instance.
        /// </summary>
        /// <param name="repo">The repository name.</param>
        /// <returns>The repository instance.</returns>
        public IRepository Repository(string repo)
        {
            return new RepositoryImpl(_restClient, repo);
        }
    }
}
