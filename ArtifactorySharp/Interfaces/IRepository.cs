using ArtifactorySharp.Models.Repository;
using RestSharp;

namespace ArtifactorySharp.Interfaces
{
    public enum RepositoryType
    {
        Unknown,
        Local,
        Remote,
        Vitrual
    }

    public interface IRepository
    {
        IRestResponse Download(string path);

        UploadingConfiguration Upload(string path, byte[] data);
    }
}
