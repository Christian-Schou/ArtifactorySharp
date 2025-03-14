﻿using ArtifactorySharp.Utils;

namespace ArtifactorySharp
{
    public enum PackageType
    {
        Custom,
        Bower,
        Cocoapods,
        Debian,
        Distribution,
        Docker,
        Gems,
        Generic,
        Gitlfs,
        Gradle,
        Ivy,
        Maven,
        Npm,
        Nuget,
        Opkg,
        P2,
        Pypi,
        Sbt,
        Vagrant,
        Vcs,
        Yum,
        Rpm,
        Composer,
        Conan,
        Chef,
        Puppet
    }

    public static class ArtifactoryBuilder
    {
        public static readonly string DefaultUserAgent = "artifactory-client-DotNet";
        public static readonly string ApiBase = "/api";
        public static readonly string DetailHeaderName = "X-Result-Detail";

        public static ArtifactoryConfiguration CreateArtifactory()
        {
            return new ArtifactoryConfiguration();
        }
    }
}
