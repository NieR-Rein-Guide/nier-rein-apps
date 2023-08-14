# nier-rein-apps (DEPRECATED)
An assortment of applications interfacing with the API of Nier Reincarnation, built on .NET5+.
This branch has been **DEPRECATED**, and the NierREincarnation nuget package is marked as legacy. All further development will be in the main branch.

The App has also been marked as deprecated and removed from the main branch due to incompatibilities with newer .NET version and lack of maintainer.

# Breaking changes
Here is a list of breaking changes when moving to the newer code-base:
- Upgrade from .NET5 to .NET7+
- AssetStudio dependency has been removed from the Core implementation. A slim version to read text assets is now built-in, but any applications using it must implement their own asset handling for other types of assets.
- Split of the NierReincarnation nuget package to NierReincarnation.Core and NierReincarnation.Api, with the later being the direct replacement.
- A number of methods have been renamed, removed or had their signatures change.