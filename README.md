# ArtifactorySharp
REST client for JFrog Artifactory service partially inspired by https://github.com/jfrog/artifactory-client-java and
forked from [Artifacotry-Client-CSharp](https://github.com/Gotcha7770/Artifactory-Client-CSharp).

The currently supported services from Artifactory are:
- Search.
- Downloading artifacts.
- Uploading artifacts.

There are three ways to create Artifactory client at the moment.

1) With implementation of `IRestClient`

```csharp
IRestClient client = new RestClient
{
    // URL is the dns name or ip address of your Artifactory server
    // without any subfolders
    BaseUrl = new Uri("http://some/url"),
    Authenticator = new HttpBasicAuthenticator("userName", "password")
};

IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetRestClient(client)
    .Build();
```

2) With implementation of `IAuthenticator`

```csharp
IAuthenticator authenticator = new HttpBasicAuthenticator("userName", "password");

IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetAuthentificator(authenticator)
    .SetUrl("http://some/url")
    .Build();
```

3) Or just a set properties

```csharp
IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetUserName("userName")
    .SetPassword("password")
    .SetUrl("http://some/url")
    .Build();
```

### Search

1) **Quick Search**

```csharp
ArtifactslList artifactsList = _artifactory.Search()
    .Repositories("repositoryName", "anotherRepositoryName")
    .ByName("*.zip")
    .Run();
    
if(artifactsList.Response.StatusCode == HttpStatusCode.OK)
    return artifactsList.Artifacts;
```

2) **Properties Search**

```csharp
ArtifactslList artifactsList = _artifactory.Search()
    .Repositories("repositoryName")
    .WithProperty("name", "someName")
    .WithProperty("version", "2.3.1")
    .WithOptions(ResponseOptions.Properties|ResponseOptions.Info)
    .Run();
```

3) **Create Period Search**

```csharp
ArtifactslList artifactsList = artifactory.Search()
    .Repositories("repositoryName")
    .ArtifactsCreatedInDateRange()
    .From(new DateTime(2018, 2, 24))
    .To(new DateTime(2018, 3, 24))
    .WithOptions(ResponseOptions.Properties)
    .Run();
```
### Download Artifacts

```csharp
 IRestResponse response = artifactory.GetRepository("repositoryName").Download("your/artifact/path");
```

### Upload Artifacts

```csharp
IRestResponse response = artifactory.GetRepository("repositoryName")
    .Upload("artifactName/artifactName.1.0.3.ext", bytes)
    .WithProperty("name", "artifactName")
    .WithProperty("version", "1.0.3")
    .WithProperty("dependencies", new[] { "dep1", "dep2" })
    .Run();
```
