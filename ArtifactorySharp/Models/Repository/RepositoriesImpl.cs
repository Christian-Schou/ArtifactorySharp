﻿using ArtifactorySharp.Interfaces;
using RestSharp;

namespace ArtifactorySharp.Models.Repository
{
    public class RepositoriesImpl : IRepositories
    {
        private IRestClient _restClient;

        public RepositoriesImpl(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IRepository Repository(string repo)
        {
            return new RepositoriyImpl(_restClient, repo);
        }
    }
}
