![](GithubAssets/SharpRinth.png)

# SharpRinth
Modrinth API wrapper for C#

## Getting Started
To start using the API create a new instance of `ModrinthClient`
```csharp
ModrinthClient client = new();
```
Then you can use the built-in methods for using the API

## Documentation
Most documentation is found within the source code

## Disclaimer
This wrapper only focuses on getting information from the Modrinth API. That means there is no functionality mod post/remove data (i.e Upload or Delete mods).
I might later add support for this, but as it stands it's not on my radar
